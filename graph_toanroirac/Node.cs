using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class Node
    {
        public char DisplayName;
        public int Index { get; set; }
        public Node (int Index)
        {
            this.Index = Index;
        }
    }
}
