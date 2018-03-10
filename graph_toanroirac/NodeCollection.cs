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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
