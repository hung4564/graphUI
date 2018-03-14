using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace graph_toanroirac
{
    public partial class Form1 : Form
    {
        string filematrix = "matrix.txt";
        string filePoint = "point.txt";
        public Form1()
        {
            InitializeComponent();
            list_edge.FormattingEnabled = false;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Click += new EventHandler(toolStripButton_Click);
            }
            graphUI1.DrawEvent += GraphUI1_DrawEvent;
            graphUI1.GraphChange += GraphUI1_GraphChange;
        }

        private void GraphUI1_GraphChange(object sender, EventArgs e)
        {
            LoadListEdge();
        }

        private void GraphUI1_DrawEvent(object sender,EventArgs e)
        {
            Edge edge = sender as Edge;
            Form2 f = new Form2();
            f.ShowDialog();
            edge.weight = f.weight;
        }

        private void btnDeleteLastestEdge_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteLastestEdge();
            LoadListEdge();
        }
        protected override void OnLoad(EventArgs e)
        {
            LoadGrap(filematrix, filePoint);
            base.OnShown(e);
        }
        void LoadGrap(string matrix,string point)
        {
            GraphData data = graphUI1.LoadGraph(matrix, point);
            chkUndirectedGrapth.Checked = data.IsUndirectedGraph;
            LoadListEdge();
        }
        void LoadListEdge()
        {
            list_edge.Items.Clear();
            if (graphUI1.Data != null)
            {
                foreach (Edge item in graphUI1.Data.edgeCollection)
                {
                    list_edge.Items.Add(item);
                }
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            graphUI1.SaveGraph(filematrix, filePoint);
            base.OnClosing(e);
        }
        private void graphUI1_SelectedNodeChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = sender != null;
        }
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;

            DrawingTools tool = (DrawingTools)(int.Parse(btn.Tag.ToString()));
            graphUI1.Tool = tool;
            foreach (ToolStripButton item in toolStrip1.Items)
            {
                item.Checked = false;
            }

            btn.Checked = true;
        }

        private void chkUndirectedGrapth_CheckedChanged(object sender, EventArgs e)
        {
            graphUI1.IsUndirectedGraph = chkUndirectedGrapth.Checked;
        }

        private void btnClearEdge_Click(object sender, EventArgs e)
        {
            graphUI1.ClearEdges();
            LoadListEdge();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphUI1.Clear();
        }
        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteSelectedNode();
        }

        private void btnChangeNodeColor_Click(object sender, EventArgs e)
        {

            NodeUI node = graphUI1.SelectedNode;
            if (node == null)
                return;
            ColorDialog dlg = new ColorDialog();
            dlg.Color = node.BackColor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = dlg.Color;
                node.BackColor = c;
                node.ForeColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);

                if (Math.Abs(c.ToArgb() - node.ForeColor.ToArgb()) < 100000)
                {

                    node.ForeColor = Color.Black;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
            graphUI1.Kruskal();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadGrap(filematrix, filePoint);
            graphUI1.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            graphUI1.SaveGraph(filematrix, filePoint);
        }

        private void btnResetEdge_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
            graphUI1.Prim(graphUI1.SelectedNode.node);
        }

        private void list_edge_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge edge = list_edge.SelectedItem as Edge;
            if (edge != null)
            {
                graphUI1.Reset();
                edge.IsSelected = true;
                graphUI1.Invalidate();
            }

        }

        private void edit_edge_btn_Click(object sender, EventArgs e)
        {
            Edge edge = list_edge.SelectedItem as Edge;
            if (edge != null)
            {
                Form2 f = new Form2();
                f.weight = edge.weight;
                f.ShowDialog();
                edge.weight = f.weight;
                LoadListEdge();
                graphUI1.Invalidate();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Edge edge = list_edge.SelectedItem as Edge;
            if (edge != null)
            {
                graphUI1.DeleteEdge(edge);
                LoadListEdge();
                graphUI1.Invalidate();
            }
        }
    }
}
