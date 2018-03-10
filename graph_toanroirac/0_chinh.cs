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
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Click += new EventHandler(toolStripButton_Click);
            }
        }
        private void btnDeleteLastestEdge_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteLastestEdge();
        }
        protected override void OnLoad(EventArgs e)
        {
            GraphData data = graphUI1.LoadGraph(filematrix, filePoint);
            chkUndirectedGrapth.Checked = data.IsUndirectedGraph;
            base.OnShown(e);
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
                //MessageBox.Show(Color.Black.GetBrightness().ToString()+"      " + Color.White.GetBrightness().ToString());

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
            graphUI1.Kruskal();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            graphUI1.LoadGraph(filematrix, filePoint);
            graphUI1.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            graphUI1.SaveGraph(filematrix, filePoint);
        }

        private void btnResetEdge_Click(object sender, EventArgs e)
        {
            graphUI1.ResetEdges();
        }
    }
}
