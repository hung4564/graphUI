
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class Edge : IEquatable<Edge>, IComparable<Edge>
    {
        /// <summary>
        /// Đỉnh bắt đầu của cạnh
        /// </summary>
        public int start;
        /// <summary>
        /// Đỉnh cuối của cạnh
        /// </summary>
        public int end;
        /// <summary>
        /// Trọng số của cạnh
        /// </summary>
        public int weight;
        /// <summary>
        /// True là vô hướng
        /// </summary>
        public bool IsUndirected;
        public Edge()
        {

        }
        public Edge(int start, int end, int weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }

        public override string ToString()
        {
            return string.Format("{0}->{1}:{2}", start + 1, end + 1, weight);
        }
        public int CompareTo(Edge other)
        {
            if (other == null)
                return 1;

            else
                return this.weight.CompareTo(other.weight);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Edge objAsEdge = obj as Edge;
            if (objAsEdge == null) return false;
            else return Equals(objAsEdge);
        }
        public override int GetHashCode()
        {
            return weight;
        }
        public bool Equals(Edge other)
        {
            if (other == null) return false;
            return (this.weight.Equals(other.weight));
        }
    }
    
}
