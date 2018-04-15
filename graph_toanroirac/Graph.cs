using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Graph
    {
        public event EventHandler GraphChange;

        public int n
        {
            get { return _nodeList.Count; }
        }
        EdgeCollection _edgeList;
        NodeCollection _nodeList;
        public EdgeCollection edgeCollection
        {
            get { return _edgeList; }
            set { _edgeList = value; }
        }
        public NodeCollection nodeCollection
        {
            get { return _nodeList; }
            set { _nodeList = value; }
        }
        /// <summary>
        /// true là vô hướng, false là có hướng
        /// </summary>
        public bool IsUndirected;
        public Graph()
        {
            khoitao();
        }
        public Graph(Matrix matrix)
        {
            khoitao();
            matrix_convert(matrix);
        }
        void khoitao()
        {
            _edgeList = new EdgeCollection();
            _nodeList = new NodeCollection();
            this.IsUndirected = false;
        }
        /// <summary>
        /// Tìm cây khung nhỏ nhất theo thuật toán Krukal
        /// </summary>
        public EdgeCollection Kruskal()
        {
            Reset();
            EdgeCollection listResult = new EdgeCollection();
            _edgeList.Sort();
            //danh dau nhan i cho dinh i
            int[] label = new int[n];
            for (int i = 0; i < n; i++)
            {
                label[i] = i;
            }
            int lab1 = 0;
            int lab2 = 0;
            foreach (Edge item in _edgeList)
            {
                if (label[item.start.Index] != label[item.end.Index])
                {
                    listResult.Add(item);
                    if (label[item.start.Index] > label[item.end.Index])
                    {
                        lab1 = label[item.end.Index];
                        lab2 = label[item.start.Index];
                    }
                    else
                    {
                        lab2 = label[item.end.Index];
                        lab1 = label[item.start.Index];
                    }
                    for (int i = 0; i < n; i++)
                    {
                        if (label[i] == lab2) label[i] = lab1;
                    }
                }
            }
            return listResult;
        }
        /// <summary>
        /// Tìm cây khung nhỏ nhất theo thuật toán Prim
        /// </summary>
        public EdgeCollection Prim(Node startNode = null)
        {
            Reset();
            EdgeCollection listResult = new EdgeCollection();
            if (startNode == null) startNode = _nodeList[0];
            Node node = startNode;
            node.IsVisit = true;
            NodeCollection nodes = new NodeCollection();
            nodes.Add(node);
            Edge edge = null;
            int min = 0;
            int n = 0;
            while (!_nodeList.IsAllVisit)
            {
                n++;
                min = 0;
                EdgeCollection edges = GetAllEdgeFromNodes(nodes);
                foreach (Edge item in edges)
                {
                    if (min > item.weight || min == 0)
                    {
                        min = item.weight;
                        edge = item;
                    }
                }
                if (edge != null)
                {
                    listResult.Add(edge);
                    edge.start.IsVisit = true;
                    edge.end.IsVisit = true;
                    nodes.Add(edge.start);
                    nodes.Add(edge.end);
                }
            }
            return listResult;
        }
        /// <summary>
        /// Kiểm tra tính liên thông của đồ thị
        /// </summary>
        /// <returns>true nếu đúng</returns>
        public bool ISLienthong()
        {
            Reset();
            BFS(_nodeList[0]);
            bool check = _nodeList.IsAllVisit;
            Reset();
            return check;
        }
        public List<NodeCollection> Lienthong()
        {
            NodeCollection nodes = _nodeList;
            NodeCollection lienthong;
            List<NodeCollection> list = new List<NodeCollection>();
            while (nodes != null)
            {
                lienthong = BFS(nodes[0]);
                list.Add(lienthong);
                nodes = NodeCollection.hieu(nodes, lienthong);
            }
            return list;
        }
        public List<NodeCollection> IsHaiPhia()
        {
            Reset();
            NodeCollection phia1 = new NodeCollection();
            NodeCollection phia2 = new NodeCollection();
            NodeCollection T;
            bool falg = true;
            phia1.Add(_nodeList[0]);
            _nodeList[0].IsVisit = true;
            do
            {
                foreach (Node node in phia1)
                {
                    EdgeCollection edges = _edgeList[node];
                    foreach (Edge edge in edges)
                    {
                        Node node_them = edge.start == node ? edge.end : edge.start;
                        phia2.Add(node_them);
                    }
                }
                T = new NodeCollection();
                foreach (Node node in phia2)
                {
                    EdgeCollection edges = _edgeList[node];
                    foreach (Edge edge in edges)
                    {
                        Node node_them = edge.start == node ? edge.end : edge.start;
                        T.Add(node_them);
                    }
                }
                if (T.Equal(phia1)) break;
                phia1 = T;
                if (NodeCollection.giao(phia1, phia2))
                {
                    falg = false;
                    break;
                }
            }
            while (true);
            if (!falg) return null;
            return new List<NodeCollection>() { phia1, phia2 };
        }
        public NodeCollection BFS(Node node)
        {
            Reset();
            NodeCollection edges_result = null;
            if (n > 0)
            {
                edges_result = new NodeCollection();
                edges_result.Add(node);
                Queue<Node> queue_nodes = new Queue<Node>();
                queue_nodes.Enqueue(node);
                node.IsVisit = true;
                while (queue_nodes.Count > 0)
                {
                    node = queue_nodes.Dequeue();
                    EdgeCollection edges = _edgeList[node];
                    if (edges != null)
                    {
                        foreach (Edge edge in edges)
                        {
                            Node node_them = edge.start == node ? edge.end : edge.start;
                            if (!node_them.IsVisit)
                            {
                                node_them.IsVisit = true;
                                queue_nodes.Enqueue(node_them);
                                edges_result.Add(node_them);
                                edge.IsSelected = true;
                            }
                        }
                    }
                }
            }
            return edges_result;
        }
        public EdgeCollection GetAllEdgeFromNodes(IEnumerable<Node> nodes)
        {
            EdgeCollection edgeCollection = new EdgeCollection();
            foreach (Edge edge in _edgeList)
            {
                if (nodes.Contains(edge.start) && edge.start.IsVisit && !edge.end.IsVisit)
                {
                    edgeCollection.Add(edge);
                }
                else
                {
                    if (edge.IsUndirected && edge.end.IsVisit && !edge.start.IsVisit && nodes.Contains(edge.end))
                    {
                        edgeCollection.Add(edge);
                    }
                }
            }
            return edgeCollection;
        }
        void matrix_convert(Matrix a)
        {
            Clear();
            for (int i = 0; i < a.n; i++)
            {
                _nodeList.Add(new Node(i));
            }
            for (int i = 0; i < a.n; i++)
            {
                Node start = _nodeList[i];
                for (int j = 0; j < a.n; j++)
                {
                    if (a[i, j] != 0)
                    {
                        Node end = _nodeList[j];
                        Edge edge = new Edge(start, end, a[i, j]);
                        _edgeList.Add(edge);
                    }
                }
            }
            IsUndirected = true;
            for (int i = 0; i < _edgeList.Count; i++)
            {
                if (_edgeList[i].IsUndirected == false)
                {
                    IsUndirected = false;
                    break;
                }
            }
            xdBac_node();
        }
        Matrix graph_convert()
        {
            Matrix matrix = new Matrix(n);
            foreach (Edge item in _edgeList)
            {
                matrix[item.start.Index, item.end.Index] = item.weight;
                if (item.IsUndirected || this.IsUndirected) matrix[item.end.Index, item.start.Index] = item.weight;
            }
            return matrix;
        }
        public void AddNode(Node newNode)
        {
            _nodeList.Add(newNode);
            ResetSubNode();
        }
        public void DeleteNode(Node node)
        {
            if (_nodeList.Contains(node))
            {
                _edgeList.RemoveBy(node);
                _nodeList.Remove(node);
                ResetSubNode();
            }
        }
        void ResetSubNode()
        {
            for (int i = 0; i < n; i++)
            {
                _nodeList[i].Index = i;
            }
            OnGraphChange(null, null);
        }
        public void AddEdge(Node start, Node end, int weight)
        {
            Edge edge = new Edge(start, end, weight);
            edge.IsUndirected = this.IsUndirected;
            AddEdge(edge);
        }
        public void AddEdge(Edge edge)
        {
            //Nếu đỉnh của cạnh tồn tại
            if (_nodeList.Contains(edge.start) && _nodeList.Contains(edge.end))
            {
                edge.IsUndirected = this.IsUndirected;
                _edgeList.Add(edge);
                OnGraphChange(null, null);
            }
        }
        public bool DeleteEdeg(Edge edge)
        {
            if (_edgeList.Contains(edge))
            {
                _edgeList.Remove(edge);
                OnGraphChange(null, null);
                return true;
            }
            return false;
        }
        public void ClearEdge()
        {
            _edgeList.Clear();
            OnGraphChange(null, null);
        }
        public void Clear()
        {
            _edgeList.Clear();
            _nodeList.Clear();
            OnGraphChange(null, null);
        }
        public void ReadFile(string filename)
        {
            Matrix matrix = new Matrix();
            matrix.ReadMatrix(filename);
            matrix_convert(matrix);
        }
        public void WriteFIle(string filename)
        {
            Matrix matrix = graph_convert();
            matrix.WriteMarix(filename);
        }
        public void Reset()
        {
            _nodeList.Reset();
            _edgeList.Reset();
        }
        protected virtual void OnGraphChange(object sender, EventArgs e)
        {
            xdBac_node();
            if (GraphChange != null)
                GraphChange(sender, e);
        }
        public void CreatGraphRandom(int count)
        {
            Matrix a = new Matrix();
            a.CreatMatrixRandom(count);
            matrix_convert(a);
        }

        private void xdBac_node()
        {
            //Tạm thời chỉ xd với đò thị vô hướng
            foreach (Node node in _nodeList)
            {
                node.deg = 0;
            }
            foreach (Edge edge in _edgeList)
            {
                if (edge.IsUndirected)
                {
                    edge.start.deg++;
                    edge.end.deg++;
                }
                else
                {
                    edge.start.deg++;
                }
            }
        }
        public int kiemtraEuler()
        {
            //0 là ko tồn tại, 1 là có đường đi , 2 là có chu trình
            //ĐK có chu trình euler là ko có đỉnh bậc lẻ, có đường đi là có đúng 2 đỉnh bậc lẻ
            if (!ISLienthong())
                return 0;
            xdBac_node();
            int count_odd_node = 0;
            foreach (Node node in _nodeList)
            {
                if (node.deg % 2 != 0)
                {
                    count_odd_node++;
                    if (count_odd_node > 2) return 0;
                }
            }
            if (count_odd_node == 0) return 2;
            else return 1;
        }
        public List<Node> Euler(Node node)
        {
            int check = kiemtraEuler();
            if (check == 0)
            {
                return null;
            }
            else if (check == 1)
            {
                if (node.deg % 2 == 0)//xác định đỉnh bậc lẻ làm đầu đường đi
                {
                    foreach (Node item in _nodeList)
                    {
                        if (item.deg % 2 != 0)
                        {
                            node = item;
                            break;
                        }
                    }
                }
            }
            return Euler_flor(node);
        }
        public List<Node> Euler_flor(Node start)
        {
            Reset();
            //EdgeCollection result = new EdgeCollection();
            List<Node> nodes = new List<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                Node node = stack.Peek();
                bool has_edge = false;
                foreach (Edge edge in _edgeList)
                {
                    if (edge.start == node || (edge.IsUndirected && edge.end == node))
                        if (!edge.IsRemoving)
                        {
                            edge.IsRemoving = true;
                            has_edge = true;
                            if (edge.start == node) stack.Push(edge.end);
                            else stack.Push(edge.start);
                            break;
                        }
                }
                if (!has_edge)
                {
                    node = stack.Pop();
                    nodes.Add(node);
                }
            }
            return nodes;
            //for (int i = 0; i < nodes.Count-1; i++)
            //{
            //    result.Add(_edgeList[nodes[i], nodes[i + 1]]);
            //}
            //return result;
        }
    }
}
