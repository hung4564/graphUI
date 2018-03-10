using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Graph
    {
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
        /// Kiểm tra tính liên thông của ma trận
        /// </summary>
        /// <returns>Trả về đúng nếu liên thông</returns>
        public bool Is_lienthong()
        {
            return false;
        }
        /// <summary>
        /// Kiểm tra tính đầy đủ của ma trận
        /// </summary>
        /// <returns>
        /// Trả về đúng nếu là ma trận đầy đủ
        /// </returns>
        public bool Is_daydu()
        {
            return false;
        }
        /// <summary>
        /// Duyệt theo chiều sâu
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Deep(int start = 0)
        {

        }
        /// <summary>
        /// Duyệt theo chiều rộng
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Breadth(int start = 0)
        {

        }
        /// <summary>
        /// Tìm cây khung nhỏ nhất theo thuật toán Kruskal
        /// </summary>
        public void Kruskal()
        {
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
                    item.IsSelected = true;
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
        }
        public void matrix_convert(Matrix a)
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
        public Matrix graph_convert()
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
        void ResetSubNode()
        {
            for (int i = 0; i < n; i++)
            {
                _nodeList[i].Index = i;
            }
        }
        public void AddEdge(Node start, Node end, int weight)
        {
            Edge edge = new Edge(start, end, weight);
            AddEdge(edge);
        }
        public void AddEdge(Edge edge)
        {
            //Nếu đỉnh của cạnh tồn tại
            if (_nodeList.Contains(edge.start) && _nodeList.Contains(edge.end))
            {
                _edgeList.Add(edge);
            }
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
        public bool DeleteEdeg(Edge edge)
        {
            if (_edgeList.Contains(edge))
            {
                _edgeList.Remove(edge);
                return true;
            }
            return false;
        }
        public void ClearEdge()
        {
            _edgeList.Clear();
        }
        public void Clear()
        {
            _edgeList.Clear();
            _nodeList.Clear();
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
        public void ResetEdge()
        {
            _edgeList.Reset();
        }
    }
}
