using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace graph_toanroirac
{
    class GraphUI : Control
    {
        public event EventHandler SelectedNodeChanged;
        Graph _graph;
        public Graph Data
        {
            get { return _graph; }
            set { _graph = value; }
        }
        public const int NODE_RADIUS = 12;
        public const int NODE_DIAMETER = NODE_RADIUS * 2;
        Pen _penEdge;
        public DrawingTools Tool;
        public IEnumerable<char> NodeNames
        {
            get
            {
                List<char> list = new List<char>();
                for (int i = 0; i < this.Controls.Count - 1; i++)
                {
                    list.Add((char)('A' + i));
                }
                return list;
            }
        }
        public bool IsUndirectedGraph
        {
            get { return _graph.IsUndirected; }
            set
            {
                _graph.IsUndirected = value;
                if (value)
                    _penEdge.EndCap = LineCap.NoAnchor;
                else
                    _penEdge.EndCap = LineCap.ArrowAnchor;
                //RefreshMatrix();
                Invalidate();
            }
        }

        Point _startPoint;
        Node _startNode;
        Point _p;
        int _selectedIndex;
        public NodeUI SelectedNode
        {
            get
            {
                if (_selectedIndex < 0)
                    return null;
                return this.Controls[_selectedIndex] as NodeUI;
            }
        }
        public GraphUI()
        {
            this.DoubleBuffered = true;
            Control.CheckForIllegalCrossThreadCalls = false;

            _penEdge = new Pen(Color.MediumPurple, 4);
            _penEdge.EndCap = LineCap.ArrowAnchor;

            _graph = new Graph();
            //Reset();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //foreach(Control ctl in this.Controls)

            if (e.Button == MouseButtons.Left)
            {
                if (this.Tool == DrawingTools.Node)
                {
                    int m = 'Z' - 'A' + 2;
                    if (this.Controls.Count == m)
                    {
                        MessageBox.Show("You can only add " + m + " nodes to graph");
                        return;
                    }
                    AddNewNode(e.Location);

                }
                else
                if (this.Tool == DrawingTools.Edge || this.Tool == DrawingTools.Eraser)
                {
                    int count = 0;
                    foreach (Edge edge in _graph.edgeCollection)
                    {
                        //Vi tri bat dau cua canh
                        var start = this.Controls[edge.start.Index].Location;
                        start.X += NODE_RADIUS;
                        start.Y += NODE_RADIUS;

                        var end = this.Controls[edge.end.Index].Location;
                        end.X += NODE_RADIUS;
                        end.Y += NODE_RADIUS;
                        if (Edge.Contains(start, end, e.Location))
                        {
                            if (this.Tool == DrawingTools.Edge)
                            {
                                _graph.edgeCollection.SelectedIndex = count;
                            }
                            else if (this.Tool == DrawingTools.Eraser)
                            {
                                _graph.edgeCollection.RemoveAt(count);
                                _graph.edgeCollection.SelectedIndex = -1;
                            }
                            this.Invalidate();

                            break;
                        }
                        count++;
                    }
                }
                else if (this.Tool == DrawingTools.Eraser) // delete edge
                {

                }
            }
            //OnContentChanged(null, null);
            base.OnMouseDown(e);
        }
        protected virtual void OnSeletedNodeChanged(object sender, EventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, null);
        }
        public void ClearEdges()
        {
            _graph.ClearEdge();
            Invalidate();
        }
        public void Reset()
        {
            _graph.Clear();
            this.Controls.Clear();
            Invalidate();
        }

        #region mouse_event
        void Node_MouseDown(object sender, MouseEventArgs e)
        {
            NodeUI ctl = (NodeUI)sender;
            if (e.Button == MouseButtons.Left)
            {
                if (_selectedIndex >= 0)
                {
                    NodeUI node = this.Controls[_selectedIndex] as NodeUI;
                    node.Selected = false;
                    node.Invalidate();
                }

                this._selectedIndex = ctl.Index;
                OnSeletedNodeChanged(sender, null);

                ctl.Selected = true;
                ctl.Invalidate();

                if (this.Tool == DrawingTools.Select || this.Tool == DrawingTools.Node)
                    _p = e.Location;
                else if (this.Tool == DrawingTools.Edge)
                {
                    _p = this.PointToClient((ctl.PointToScreen(e.Location)));
                    _startNode = ctl.node;
                    _startPoint = ctl.Location;
                }
                else if (this.Tool == DrawingTools.Eraser)
                {
                    DeleteSelectedNode();
                }
            }
        }
        void Node_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctl = (Control)sender;

            if (e.Button == MouseButtons.Left)
            {

                Point p = this.PointToClient(ctl.PointToScreen(e.Location));
                if (this.Tool == DrawingTools.Select || this.Tool == DrawingTools.Node)
                {
                    if (p.X > 0 && p.Y > 0 && p.X < this.Width && p.Y < this.Height)
                    {
                        p.X -= _p.X;
                        p.Y -= _p.Y;

                        ctl.Location = p;

                        Invalidate();
                    }
                }

                else if (this.Tool == DrawingTools.Edge)
                {
                    Point p2 = this.PointToClient(ctl.PointToScreen(e.Location));
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.DrawLine(Pens.Red, _p, p2);
                        Invalidate();
                    }
                }
            }
        }
        void Node_MouseUp(object sender, MouseEventArgs e)
        {
            NodeUI ctl = (NodeUI)sender;
            if (e.Button == MouseButtons.Left)
            {
                if (this.Tool == DrawingTools.Edge)
                {
                    Point p2 = this.PointToClient(ctl.PointToScreen(e.Location));
                    NodeUI node = this.GetChildAtPoint(p2) as NodeUI;
                    if (node != null)
                    {
                        Form2 f = new Form2();
                        f.ShowDialog();
                        int weight = f.weight;
                        _graph.AddEdge(new Edge(_startNode, node.node, weight));
                    }
                }
                Invalidate();
            }
        }
        #endregion
        public void DeleteLastestEdge()
        {
            if (_graph.edgeCollection.Count > 0)
            {
                DeleteEdgeAt(_graph.edgeCollection.Count - 1);
            }
        }
        public void DeleteSelectedNode()
        {
            if (_selectedIndex < 0)
                return;
            int i = 0;
            while (i < _graph.edgeCollection.Count)
            {
                Edge edge = _graph.edgeCollection[i];
                if (edge.end.Index == _selectedIndex || edge.start.Index == _selectedIndex)
                {
                    DeleteEdgeAt(i);
                }
                else
                {
                    if (edge.start.Index >= _selectedIndex)
                        edge.start.Index--;
                    if (edge.end.Index >= _selectedIndex)
                        edge.end.Index--;
                    i++;
                }
            }

            NodeUI n = this.Controls[_selectedIndex] as NodeUI;
            n.DoRemovingAnimation();
            this.Controls.RemoveAt(_selectedIndex);
            _graph.DeleteNode(n.node);
            RefreshSubControls();
            Invalidate();
        }
        private void DeleteEdgeAt(int index)
        {
            _graph.edgeCollection[index].IsRemoving = true;
            Refresh();
            _graph.DeleteEdeg(_graph.edgeCollection[index]);
            Invalidate();
        }
        void RefreshSubControls()
        {
            this._selectedIndex = -1;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                NodeUI node = this.Controls[i] as NodeUI;
                node.Index = i;
                node.DisplayName = (char)('A' + i );
                node.Invalidate();
            }
            OnSeletedNodeChanged(null, null);
        }
        private void AddNewNode(Point location)
        {
            NodeUI n = new NodeUI();
            n.Index = this.Controls.Count;
            n.DisplayName = (char)(n.Index + 'A');
            n.Location = location;
            this.Controls.Add(n);
            n.DoCreatingAnimation();
            n.Width = NODE_DIAMETER;
            n.Height = NODE_DIAMETER;
            _graph.AddNode(n.node);
            n.MouseDown += new MouseEventHandler(Node_MouseDown);
            n.MouseMove += new MouseEventHandler(Node_MouseMove);
            n.MouseUp += new MouseEventHandler(Node_MouseUp);
        }
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int count = 0;
            foreach (var item in _graph.edgeCollection)
            {
                Control ctl1 = this.Controls[item.start.Index];
                Control ctl2 = this.Controls[item.end.Index];
                PointF p1 = ctl1.Location;
                PointF p2 = ctl2.Location;

                DrawEdge(g, item, p1, p2);
                count++;
            }

            g.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);

            base.OnPaint(e);
        }
        void DrawEdge(Graphics g, Edge item, PointF p1, PointF p2)
        {
            string distance = item.weight.ToString();

            p1.X += NODE_RADIUS;
            p1.Y += NODE_RADIUS;
            p2.X += NODE_RADIUS;
            p2.Y += NODE_RADIUS;

            Vector2D v1 = new Vector2D(p1.X - p2.X, p1.Y - p2.Y);
            if (v1.Length - NODE_RADIUS > 0)
            {
                v1.Contract(NODE_RADIUS);
                p1.X = p2.X + v1.X;
                p1.Y = p2.Y + v1.Y;
            }
            Vector2D v = new Vector2D(p2.X - p1.X, p2.Y - p1.Y);
            if (v.Length - NODE_RADIUS > 0)
            {
                v.Contract(NODE_RADIUS);
                p2.X = p1.X + v.X;
                p2.Y = p1.Y + v.Y;
            }
            if (!IsUndirectedGraph && item.IsUndirected)
            {
                _penEdge.StartCap = LineCap.ArrowAnchor;
            }
            else
                _penEdge.StartCap = LineCap.NoAnchor;

            if (item.IsRemoving)
            {
                Pen p = new Pen(Color.Red, 4);
                g.DrawLine(p, p1, p2);

            }
            else
            {
                g.DrawLine(_penEdge, p1, p2);
            }


            // draw distance
            SizeF size = g.MeasureString(distance, this.Font);
            PointF pp = p1;
            pp.X += p2.X;
            pp.Y += p2.Y;
            pp.X /= 2;
            pp.Y /= 2;
            pp.X -= size.Width / 2;
            pp.Y -= size.Height / 2;
            g.FillEllipse(Brushes.Yellow, pp.X - 5, pp.Y - 5, size.Width + 10, size.Height + 5);
            g.DrawString(distance.ToString(), this.Font, Brushes.Blue, pp);
        }
        #region Save/Load

        public void SaveGraph(string filematrix, string filePoint)
        {

            GraphData data = new GraphData();
            data.IsUndirectedGraph = IsUndirectedGraph;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                Point p = this.Controls[i].Location;
                p.Offset(NODE_RADIUS, NODE_RADIUS);

                data.NodeLocations.Add(p);
            }
            data.graph = _graph;
            try
            {
                data.SaveData(filematrix,filePoint);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public GraphData LoadGraph(string filematrix, string filePoint)
        {
            try
            {
                GraphData data = new GraphData();
                data.LoadData(filematrix, filePoint);
                _graph = data.graph;
                _graph.IsUndirected = data.IsUndirectedGraph;
                for (int i = 0; i < data.graph.nodeCollection.Count; i++)
                {
                    NodeUI n = new NodeUI();
                    n.Index = this.Controls.Count;
                    n.DisplayName = (char)(n.Index + 'A');
                    if (data.graph.nodeCollection.Count < data.NodeLocations.Count)
                        n.Location = data.NodeLocations[i];
                    else
                        n.Location = GetRandomLocaition();
                    n.node = data.graph.nodeCollection[i];
                    this.Controls.Add(n);
                    n.DoCreatingAnimation();
                    n.Width = NODE_DIAMETER;
                    n.Height = NODE_DIAMETER;
                    n.MouseDown += new MouseEventHandler(Node_MouseDown);
                    n.MouseMove += new MouseEventHandler(Node_MouseMove);
                    n.MouseUp += new MouseEventHandler(Node_MouseUp);
                }
                return data;

            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        #endregion
        Point GetRandomLocaition()
        {
            Random random = new Random();
            Point point = new Point();
            point.X = random.Next(NODE_RADIUS, this.Width - NODE_RADIUS);
            point.Y = random.Next(NODE_RADIUS, this.Height - NODE_RADIUS);
            return point;
        }
    }
}
