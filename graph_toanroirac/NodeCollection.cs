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
            return _list.Contains(node) ;
        }
        public void Add(Node node)
        {
            // đánh lại chỉ số của node
            node.Index = _list.Count;
            _list.Add(node);
        }
        public bool Remove(Node node)
        {
            if (_list.Contains(node))
            {
                int index = _list.IndexOf(node);
                _list.RemoveAt(index);
                for (int i = index; i < _list.Count; i++)
                {
                    _list[i].Index = i;
                }
                return true;
            }
            return false;
        }
        public IEnumerator<Node> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
