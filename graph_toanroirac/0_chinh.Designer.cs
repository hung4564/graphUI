namespace graph_toanroirac
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            graph_toanroirac.Graph graph2 = new graph_toanroirac.Graph();
            graph_toanroirac.EdgeCollection edgeCollection2 = new graph_toanroirac.EdgeCollection();
            graph_toanroirac.NodeCollection nodeCollection2 = new graph_toanroirac.NodeCollection();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_haiphia = new System.Windows.Forms.Button();
            this.btn_lienthong = new System.Windows.Forms.Button();
            this.btn_BFS = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_createGraph = new System.Windows.Forms.Button();
            this.btnClearEdge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_info = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.chkUndirectedGrapth = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rd_euler = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.edit_edge_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rd_Kruskal = new System.Windows.Forms.RadioButton();
            this.rd_prim = new System.Windows.Forms.RadioButton();
            this.btn_euler = new System.Windows.Forms.Button();
            this.graphUI1 = new graph_toanroirac.GraphUI();
            this.rd_eule = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 50);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GraphTools";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(249, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(57, 22);
            this.toolStripButton5.Tag = "0";
            this.toolStripButton5.Text = "&Move";
            this.toolStripButton5.ToolTipText = "Move (1)";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton6.Tag = "1";
            this.toolStripButton6.Text = "&Node";
            this.toolStripButton6.ToolTipText = "Node (2)";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton7.Tag = "2";
            this.toolStripButton7.Text = "&Edge";
            this.toolStripButton7.ToolTipText = "Edge (3)";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton8.Tag = "3";
            this.toolStripButton8.Text = "E&raser";
            this.toolStripButton8.ToolTipText = "Eraser (4)";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btn_haiphia);
            this.panel1.Controls.Add(this.btn_lienthong);
            this.panel1.Controls.Add(this.btn_BFS);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btn_createGraph);
            this.panel1.Controls.Add(this.btnClearEdge);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkUndirectedGrapth);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(15, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 360);
            this.panel1.TabIndex = 11;
            // 
            // btn_haiphia
            // 
            this.btn_haiphia.Location = new System.Drawing.Point(110, 187);
            this.btn_haiphia.Name = "btn_haiphia";
            this.btn_haiphia.Size = new System.Drawing.Size(87, 25);
            this.btn_haiphia.TabIndex = 17;
            this.btn_haiphia.Text = "Hai phía";
            this.btn_haiphia.UseVisualStyleBackColor = true;
            this.btn_haiphia.Click += new System.EventHandler(this.btn_haiphia_Click);
            // 
            // btn_lienthong
            // 
            this.btn_lienthong.Location = new System.Drawing.Point(110, 160);
            this.btn_lienthong.Name = "btn_lienthong";
            this.btn_lienthong.Size = new System.Drawing.Size(87, 25);
            this.btn_lienthong.TabIndex = 16;
            this.btn_lienthong.Text = "Liên thông";
            this.btn_lienthong.UseVisualStyleBackColor = true;
            this.btn_lienthong.Click += new System.EventHandler(this.btn_lienthong_Click);
            // 
            // btn_BFS
            // 
            this.btn_BFS.Location = new System.Drawing.Point(5, 160);
            this.btn_BFS.Name = "btn_BFS";
            this.btn_BFS.Size = new System.Drawing.Size(87, 25);
            this.btn_BFS.TabIndex = 2;
            this.btn_BFS.Text = "BFS";
            this.btn_BFS.UseVisualStyleBackColor = true;
            this.btn_BFS.Click += new System.EventHandler(this.btn_BFS_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(4, 87);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(116, 29);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "Load Graph";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(126, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 29);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save Graph";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(127, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 32);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnResetEdge_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_euler);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(118, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 113);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thuật toán";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Prime";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 25);
            this.button3.TabIndex = 0;
            this.button3.Text = "Kruskal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_createGraph
            // 
            this.btn_createGraph.Location = new System.Drawing.Point(4, 52);
            this.btn_createGraph.Name = "btn_createGraph";
            this.btn_createGraph.Size = new System.Drawing.Size(116, 29);
            this.btn_createGraph.TabIndex = 12;
            this.btn_createGraph.Text = "Create Graph";
            this.btn_createGraph.UseVisualStyleBackColor = true;
            this.btn_createGraph.Click += new System.EventHandler(this.btn_createGraph_Click);
            // 
            // btnClearEdge
            // 
            this.btnClearEdge.Location = new System.Drawing.Point(127, 50);
            this.btnClearEdge.Name = "btnClearEdge";
            this.btnClearEdge.Size = new System.Drawing.Size(115, 32);
            this.btnClearEdge.TabIndex = 11;
            this.btnClearEdge.Text = "Clear Edges";
            this.btnClearEdge.UseVisualStyleBackColor = true;
            this.btnClearEdge.Click += new System.EventHandler(this.btnClearEdge_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_info);
            this.groupBox1.Controls.Add(this.btnDeleteNode);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Options";
            // 
            // btn_info
            // 
            this.btn_info.Location = new System.Drawing.Point(14, 50);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(87, 25);
            this.btn_info.TabIndex = 1;
            this.btn_info.Text = "Info Node";
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btnChangeNodeColor_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(14, 19);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(87, 25);
            this.btnDeleteNode.TabIndex = 0;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // chkUndirectedGrapth
            // 
            this.chkUndirectedGrapth.Location = new System.Drawing.Point(61, 218);
            this.chkUndirectedGrapth.Name = "chkUndirectedGrapth";
            this.chkUndirectedGrapth.Size = new System.Drawing.Size(118, 20);
            this.chkUndirectedGrapth.TabIndex = 8;
            this.chkUndirectedGrapth.Text = "Undirected Graph";
            this.chkUndirectedGrapth.UseVisualStyleBackColor = true;
            this.chkUndirectedGrapth.CheckedChanged += new System.EventHandler(this.chkUndirectedGrapth_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rd_euler
            // 
            this.rd_euler.FormattingEnabled = true;
            this.rd_euler.Location = new System.Drawing.Point(745, 68);
            this.rd_euler.Name = "rd_euler";
            this.rd_euler.Size = new System.Drawing.Size(263, 199);
            this.rd_euler.TabIndex = 1;
            this.rd_euler.SelectedIndexChanged += new System.EventHandler(this.list_edge_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.toolStrip2);
            this.groupBox4.Location = new System.Drawing.Point(745, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 50);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EdgeTools";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit_edge_btn,
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(257, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // edit_edge_btn
            // 
            this.edit_edge_btn.Image = ((System.Drawing.Image)(resources.GetObject("edit_edge_btn.Image")));
            this.edit_edge_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit_edge_btn.Name = "edit_edge_btn";
            this.edit_edge_btn.Size = new System.Drawing.Size(47, 22);
            this.edit_edge_btn.Tag = "2";
            this.edit_edge_btn.Text = "&Edit";
            this.edit_edge_btn.ToolTipText = "Edge";
            this.edit_edge_btn.Click += new System.EventHandler(this.edit_edge_btn_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton4.Tag = "3";
            this.toolStripButton4.Text = "E&raser";
            this.toolStripButton4.ToolTipText = "Eraser";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_run);
            this.flowLayoutPanel1.Controls.Add(this.btn_next);
            this.flowLayoutPanel1.Controls.Add(this.btn_end);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(745, 286);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(147, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(3, 3);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(65, 32);
            this.btn_run.TabIndex = 14;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.VisibleChanged += new System.EventHandler(this.btn_run_VisibleChanged);
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(74, 3);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(65, 32);
            this.btn_next.TabIndex = 15;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(3, 41);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(65, 32);
            this.btn_end.TabIndex = 16;
            this.btn_end.Text = "End";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rd_eule);
            this.panel2.Controls.Add(this.rd_Kruskal);
            this.panel2.Controls.Add(this.rd_prim);
            this.panel2.Location = new System.Drawing.Point(898, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(115, 100);
            this.panel2.TabIndex = 12;
            // 
            // rd_Kruskal
            // 
            this.rd_Kruskal.AutoSize = true;
            this.rd_Kruskal.Location = new System.Drawing.Point(22, 41);
            this.rd_Kruskal.Name = "rd_Kruskal";
            this.rd_Kruskal.Size = new System.Drawing.Size(60, 17);
            this.rd_Kruskal.TabIndex = 1;
            this.rd_Kruskal.TabStop = true;
            this.rd_Kruskal.Text = "Kruskal";
            this.rd_Kruskal.UseVisualStyleBackColor = true;
            this.rd_Kruskal.CheckedChanged += new System.EventHandler(this.rd_Kruskal_CheckedChanged);
            // 
            // rd_prim
            // 
            this.rd_prim.AutoSize = true;
            this.rd_prim.Location = new System.Drawing.Point(22, 18);
            this.rd_prim.Name = "rd_prim";
            this.rd_prim.Size = new System.Drawing.Size(45, 17);
            this.rd_prim.TabIndex = 0;
            this.rd_prim.TabStop = true;
            this.rd_prim.Text = "Prim";
            this.rd_prim.UseVisualStyleBackColor = true;
            this.rd_prim.CheckedChanged += new System.EventHandler(this.rd_prim_CheckedChanged);
            // 
            // btn_euler
            // 
            this.btn_euler.Location = new System.Drawing.Point(14, 81);
            this.btn_euler.Name = "btn_euler";
            this.btn_euler.Size = new System.Drawing.Size(87, 25);
            this.btn_euler.TabIndex = 2;
            this.btn_euler.Text = "Euler";
            this.btn_euler.UseVisualStyleBackColor = true;
            this.btn_euler.Click += new System.EventHandler(this.btn_euler_Click);
            // 
            // graphUI1
            // 
            this.graphUI1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            edgeCollection2.SelectedIndex = 0;
            graph2.edgeCollection = edgeCollection2;
            nodeCollection2.SelectedIndex = 0;
            graph2.nodeCollection = nodeCollection2;
            this.graphUI1.Data = graph2;
            this.graphUI1.IsUndirectedGraph = false;
            this.graphUI1.Location = new System.Drawing.Point(273, 12);
            this.graphUI1.Name = "graphUI1";
            this.graphUI1.Size = new System.Drawing.Size(466, 416);
            this.graphUI1.TabIndex = 0;
            this.graphUI1.Text = "graphUI1";
            this.graphUI1.SelectedNodeChanged += new System.EventHandler(this.graphUI1_SelectedNodeChanged);
            // 
            // rd_eule
            // 
            this.rd_eule.AutoSize = true;
            this.rd_eule.Location = new System.Drawing.Point(22, 64);
            this.rd_eule.Name = "rd_eule";
            this.rd_eule.Size = new System.Drawing.Size(49, 17);
            this.rd_eule.TabIndex = 2;
            this.rd_eule.TabStop = true;
            this.rd_eule.Text = "Euler";
            this.rd_eule.UseVisualStyleBackColor = true;
            this.rd_eule.CheckedChanged += new System.EventHandler(this.rd_eule_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 440);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.rd_euler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.graphUI1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GraphUI graphUI1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearEdge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.CheckBox chkUndirectedGrapth;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_createGraph;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListBox rd_euler;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton edit_edge_btn;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rd_Kruskal;
        private System.Windows.Forms.RadioButton rd_prim;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_BFS;
        private System.Windows.Forms.Button btn_lienthong;
        private System.Windows.Forms.Button btn_haiphia;
        private System.Windows.Forms.Button btn_euler;
        private System.Windows.Forms.RadioButton rd_eule;
    }
}