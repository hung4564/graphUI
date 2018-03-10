
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class Edge : IEquatable<Edge>, IComparable<Edge>
    {
        private const float EPSILON = 2f;

        /// <summary>
        /// Đỉnh bắt đầu của cạnh
        /// </summary>
        public Node start
        {
            get
            {
                return _start;
            }
        }
        Node _start;
        /// <summary>
        /// Đỉnh cuối của cạnh
        /// </summary>
        public Node end
        {
            get { return _end; }
        }
        Node _end;
        /// <summary>
        /// Trọng số của cạnh
        /// </summary>
        public int weight;
        /// <summary>
        /// True là vô hướng
        /// </summary>
        public bool IsUndirected;
        public bool IsRemoving;
        public bool IsSelected;
        public Edge()
        {

        }
        public Edge(Node start, Node end, int weight)
        {
            this._start = start;
            this._end = end;
            this.weight = weight;
        }
        public Edge(Node start, Node end)
        {
            this._start = start;
            this._end = end;
            this.weight = 1;
        }
        public void Reset()
        {
            IsSelected = false;
            IsRemoving = false;
        }
        public override string ToString()
        {
            if(IsUndirected) return string.Format("{0}<->{1}:{2}", _start.Index + 1, _end.Index + 1, weight);
            else
            return string.Format("{0}->{1}:{2}", _start.Index+1, _end.Index+1, weight);
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
            return _start.Index ^ _end.Index;
        }
        public bool Equals(Edge other)
        {
            if (other == null) return false;
            if (this.weight.Equals(other.weight) && this._start.Equals(other._start) && this._end.Equals(other._end))
                return true;
            if (this.IsUndirected && this._start.Equals(other._end) && this._end.Equals(other._start)&&this.weight.Equals(other.weight))
                return true;
            return false;}
        public static bool Contains(PointF start, PointF end, PointF p)
        {
            if (p.X < Math.Min(start.X, end.X) ||
                    p.X > Math.Max(start.X, end.X) ||
                    p.Y < Math.Min(start.Y, end.Y) ||
                    p.Y > Math.Max(start.Y, end.Y))
                return false;
            var dx = end.X - start.X;
            var dy = end.Y - start.Y;
            var v1 = new Vector2D(dx, dy).Length;


            float cx = p.X - start.X;
            float cy = p.Y - start.Y;
            var v2 = new Vector2D(cx, cy).Length;

            var v3 = new Vector2D(p.X - end.X, p.Y - end.Y).Length;
            var pp = (v1 + v2 + v3) / 2;

            var s = Math.Sqrt(pp * (pp - v1) * (pp - v2) * (pp - v3));
            var h = s * 2 / v1;
            Console.WriteLine(h);
            return h < EPSILON;
        }
    }
    
}
