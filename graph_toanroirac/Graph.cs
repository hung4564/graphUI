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
        public EdgeCollection GetAllEdgeFromNodes(NodeCollection nodes)
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
            for (int i = 0; i < a.n; i++)
            {
                _nodeList.Add(new Node(i));
            }
            for (int i = 0; i < a.n; i++)
            {
                Node start = _nodeList[i];
                for (int j = 0; j < n; j++)
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
            if (GraphChange != null)
                GraphChange(sender, e);
        }
    }
}
