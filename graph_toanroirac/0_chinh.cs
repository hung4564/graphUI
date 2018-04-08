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
        AlgorithmTools algorithmTools;
        string filematrix = "matrix.txt";
        string filePoint = "point.txt";
        NodeCollection nodes = new NodeCollection();
        TextBox textBox;
        int[] label;
        Graph graph
        {
            get
            {
                return graphUI1.Data;
            }
        }
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
            algorithmTools = AlgorithmTools.None;
        }

        private void GraphUI1_GraphChange(object sender, EventArgs e)
        {
            LoadListEdge();
        }

        private void GraphUI1_DrawEvent(object sender, EventArgs e)
        {
            Edge edge = sender as Edge;

            Form2 f = new Form2();
            f.weight = edge.weight;
            f.ShowDialog();
            edge.weight = f.weight;
        }

        private void btnDeleteLastestEdge_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteLastestEdge();
        }
        protected override void OnLoad(EventArgs e)
        {
            LoadGrap(filematrix, filePoint);
            base.OnShown(e);
        }
        void LoadGrap(string matrix, string point)
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
            algorithmTools = AlgorithmTools.Kruskal;
            graphUI1.Kruskal();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string file = filematrix;
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Chọn file text đuôi .txt";
                open.Filter = "All Files|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (open.FileName.Contains(".txt"))
                        {
                            file = open.FileName;
                            graphUI1.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi" + ex.Message);
                    }
                }
            }
            LoadGrap(file, null);
            graphUI1.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            graphUI1.SaveGraph(filematrix, filePoint);
        }

        private void btnResetEdge_Click(object sender, EventArgs e)
        {
            algorithmTools = AlgorithmTools.None;
            rd_Kruskal.Checked = false;
            rd_prim.Checked = false;
            graphUI1.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
            algorithmTools = AlgorithmTools.Prim;
            if (graphUI1.SelectedNode == null)
            {
                MessageBox.Show("Chọn đỉnh bắt đầu trước");
            }
            else
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
                graphUI1.Invalidate();
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (algorithmTools == AlgorithmTools.None)
            {
                MessageBox.Show("CHọn thuật toán để chạy");
            }
            else if (algorithmTools == AlgorithmTools.Prim)
            {
                MessageBox.Show("Chạy thuật toán Prim");
                PrimBegin();
                btn_run.Visible = false;
            }
            else if (algorithmTools == AlgorithmTools.Kruskal)
            {
                MessageBox.Show("Chạy thuật toán Kruskal");
                KruskalBegin();
                btn_run.Visible = false;
            }
        }
        void PrimBegin()
        {
            if (graphUI1.SelectedNode == null)
            {
                MessageBox.Show("Chọn đỉnh bắt đầu trước");
            }
            else
            {
                SetTextBox();
                textBox.Clear();
                graphUI1.Reset();
                string text = "Bắt đâu từ đỉnh " + graphUI1.SelectedNode.ToString();
                textBox.Text = text + "\r\n";
                nodes.Add(graphUI1.SelectedNode.node);
                graphUI1.SelectedNode.node.IsVisit = true;
                GetEdge_prime();
            }
        }
        bool PrimNext()
        {
            if (!graph.nodeCollection.IsAllVisit)
            {
                graphUI1.Data.edgeCollection.Reset();
                GetEdge_prime();
                graphUI1.Invalidate();
                return false;
            }
            else
            {
                graphUI1.Data.edgeCollection.Reset();
                graphUI1.Invalidate();
                MessageBox.Show("Thuật toán xong");
                string text = "Kết quả là \r\n";
                foreach (var item in graphUI1._list)
                {
                    text += item.ToString() + "\r\n";
                }
                textBox.Text += text;
                MessageBox.Show(text);
                algorithmTools = AlgorithmTools.None;
                return true;
            }
        }
        void GetEdge_prime()
        {
            Edge edge = null;
            int min = 0;
            EdgeCollection edges = graphUI1.Data.GetAllEdgeFromNodes(nodes);
            string text = "Các cạnh xét :\r\n";
            foreach (Edge item in edges)
            {
                text = text + item.ToString() + "\r\n";
                item.IsSelected = true;
                if (min > item.weight || min == 0)
                {
                    min = item.weight;
                    edge = item;
                }
            }
            if (edge != null)
            {
                text += "Cạnh được chọn:\r\n";
                text += edge.ToString() + "\r\n";
                textBox.Text += text;
                graphUI1._list.Add(edge);
                edge.start.IsVisit = true;
                edge.end.IsVisit = true;
                nodes.Add(edge.start);
                nodes.Add(edge.end);
            }
        }
        void SetTextBox()
        {
            textBox = new TextBox()
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Height = 200,
                Width = 263,
                Location = new Point(745, 68)
            };
            textBox.TextChanged += (sender, e) =>
            {
                if (textBox.Visible)
                {
                    textBox.SelectionStart = textBox.TextLength;
                    textBox.ScrollToCaret();
                }
            };
            this.Controls.Add(textBox);
            list_edge.Hide();
        }
        void KruskalBegin()
        {
            sodem_kruskal = 0;
            graphUI1.Reset();
            graphUI1.Data.edgeCollection.Sort();
            LoadListEdge();
            SetTextBox();
            textBox.Clear();
            textBox.Text = "Sắp xếp lại các cạnh theo trọng số tăng dần\r\n";
            graphUI1._list.Clear();
            label = new int[graph.nodeCollection.Count];
            for (int i = 0; i < graph.nodeCollection.Count; i++)
            {
                label[i] = i;
            }
        }
        int sodem_kruskal = 0;
        bool KruskalNext()
        {
            graph.edgeCollection.Reset();
            int lab1 = 0;
            int lab2 = 0;
            string text = null;
            if (sodem_kruskal >= graph.edgeCollection.Count)
            {

                graphUI1.Invalidate();
                MessageBox.Show("Thuật toán xong");
                text = "Kết quả là \r\n";
                foreach (var item in graphUI1._list)
                {
                    text += item.ToString() + "\r\n";
                }
                MessageBox.Show(text);
                textBox.Text += text;
                algorithmTools = AlgorithmTools.None;
                return true;
            }
            Edge edge = list_edge.Items[sodem_kruskal] as Edge;
            text = "Kiếm tra cạnh " + edge.ToString() + "\r\n";
            edge.IsSelected = true;
            if (label[edge.start.Index] != label[edge.end.Index])
            {
                text += "Lấy vì không tạo thành chu trình với các cạnh còn lại\r\n";
                graphUI1._list.Add(edge);
                if (label[edge.start.Index] > label[edge.end.Index])
                {
                    lab1 = label[edge.end.Index];
                    lab2 = label[edge.start.Index];
                }
                else
                {
                    lab2 = label[edge.end.Index];
                    lab1 = label[edge.start.Index];
                }
                for (int i = 0; i < graph.nodeCollection.Count; i++)
                {
                    if (label[i] == lab2) label[i] = lab1;
                }
            }
            else
            {

                text += "Không lấy vì tạo thành chu trình với các cạnh còn lại\r\n";
            }
            textBox.Text += text;
            sodem_kruskal++;
            return false;
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (algorithmTools == AlgorithmTools.None)
            {
                MessageBox.Show("CHọn thuật toán để chạy");
            }
            else if (algorithmTools == AlgorithmTools.Prim)
            {
                if (PrimNext())
                {
                    btn_next.Visible = false;
                }
            }
            else if (algorithmTools == AlgorithmTools.Kruskal)
            {
                if (KruskalNext())
                {
                    btn_next.Visible = false;
                }
                graphUI1.Invalidate();
            }

        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            list_edge.Show();
            textBox.Hide();
            rd_Kruskal.Checked = false;
            rd_prim.Checked = false;
            btn_run.Visible = true;
        }
        private void rd_prim_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_prim.Checked) algorithmTools = AlgorithmTools.Prim;
        }

        private void rd_Kruskal_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_Kruskal.Checked) algorithmTools = AlgorithmTools.Kruskal;
        }

        private void btn_run_VisibleChanged(object sender, EventArgs e)
        {
            btn_end.Visible = !btn_run.Visible;
            btn_next.Visible = !btn_run.Visible;
            panel2.Visible = btn_run.Visible;
        }

        private void btn_BFS_Click(object sender, EventArgs e)
        {
            graphUI1.BFS();
        }

        private void btn_lienthong_Click(object sender, EventArgs e)
        {
            string tb = graphUI1.IsLienthong ? "Đồ thị liên thông" : "Đồ thị không liên thông";
            MessageBox.Show(tb);
            List<NodeCollection> list = graphUI1.Lienthong();
            for (int i = 0; i < list.Count; i++)
            {
                tb = "Thanh phan lien thong thu " + i + "\n";
                foreach (Node node in list[i])
                {
                    tb += node.ToString() + "\n";
                }
                MessageBox.Show(tb);
            }
        }

        private void btn_haiphia_Click(object sender, EventArgs e)
        {
            string tb = graphUI1.IsHaiphia ? "Đồ thị 2 phía" : "Đồ thị không 2 phía";
            MessageBox.Show(tb);
        }

        private void btn_createGraph_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            int n = f.weight;
            graphUI1.CreateGraphRandom(n);
        }
    }
}
