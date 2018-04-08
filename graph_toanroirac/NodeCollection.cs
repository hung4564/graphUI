using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class NodeCollection : IEnumerable<Node>
    {
        List<Node> _list;
        public NodeCollection()
        {
            _list = new List<Node>();
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public int SelectedIndex
        {
            get;
            set;
        }
        public Node SelectedItem
        {
            get
            {
                return _list[this.SelectedIndex];
            }
        }
        public Node this[int index]
        {
            get
            {
                return _list[index];
            }
        }
        public void Sort()
        {
            _list.Sort();
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(Node node)
        {
            return _list.Contains(node);
        }
        public void Add(Node node)
        {
            if (!_list.Contains(node))
                _list.Add(node);
        }
        public void Remove(Node node)
        {
            _list.Remove(node);
        }
        public IEnumerator<Node> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        public bool IsAllVisit
        {
            get
            {
                foreach (var item in _list)
                {
                    if (!item.IsVisit) return false;
                }
                return true;
            }
        }
        public void Reset()
        {
            foreach (var item in _list)
            {
                item.Reset();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        public static bool giao(NodeCollection nodes1,NodeCollection nodes2)
        {
            foreach (var node in nodes2)
            {
                if (nodes1.Contains(node)) return true;
            }
            return false;
        }
        public static NodeCollection hieu(NodeCollection nodes1, NodeCollection nodes2)
        {
            if (nodes1.Count > nodes2.Count)
            {
                NodeCollection result = new NodeCollection();
                foreach (Node node in nodes1)
                {
                    if (!nodes2.Contains(node)) result.Add(node);
                }
                if (result.Count > 0) return result;
                else return null;
            }
            return null;
        }
        public bool Equal(NodeCollection nodesother)
        {
            bool check = false;
            if (_list.Count != nodesother.Count) return false;
            foreach (Node node in nodesother)
            {
                if (_list.Contains(node)) check = true;
                else return false;
            }
            return check;
        }
    }
}
