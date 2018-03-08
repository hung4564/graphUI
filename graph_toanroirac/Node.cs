using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class Node : IEquatable<Node>, IComparable<Node>
    {
        public int Index { get; set; }
        public bool IsVisit;
        public Node (int Index)
        {
            this.Index = Index;
            this.IsVisit = false;
        }
        public Node()
        {
            this.Index = 0;
            this.IsVisit = false;
        }
        public override string ToString()
        {
            return string.Format("dinh {0} ",this.Index);
        }
        public int CompareTo(Node other)
        {
            if (other == null)
                return 1;

            else
                return this.Index.CompareTo(other.Index);
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
            return Index;
        }
        public bool Equals(Node other)
        {
            if (other == null) return false;
            return (this.Index.Equals(other.Index));
        }
    }
}
