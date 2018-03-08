using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Graph
    {
        int n;
        EdgeCollection edgeList;
        NodeCollection nodeList;
        /// <summary>
        /// true là vô hướng, false là có hướng
        /// </summary>
        bool IsUndirected;
        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        /// <param name="n">Số đỉnh</param>
        public Graph(int n)
        {
            this.n = n;
            edgeList = new EdgeCollection();
            nodeList = new NodeCollection();
            IsUndirected = true;
        }
        public Graph(int n,bool IsUndirected)
        {
            this.n = n;
            edgeList = new EdgeCollection();
            nodeList = new NodeCollection();
            this.IsUndirected = IsUndirected;
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
        public EdgeCollection matrix_edge_convert(int[,] a, int n)
        {
            EdgeCollection listEdge = new EdgeCollection();
            Edge edge;
            for (int i = 0; i < n; i++)
            {
                Node start = new Node(i);
                for (int j = i; j < n; j++)
                {
                    if (a[i, j] > 0)
                    {
                        Node end = new Node(j);
                        edge = new Edge(start, end, a[i, j]);
                        listEdge.Add(edge);
                    }
                }
            }
            // listEdge.Sort();
            return listEdge;
        }
    }
}
