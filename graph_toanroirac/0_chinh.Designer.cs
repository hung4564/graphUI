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
            graph_toanroirac.Graph graph3 = new graph_toanroirac.Graph();
            graph_toanroirac.EdgeCollection edgeCollection3 = new graph_toanroirac.EdgeCollection();
            graph_toanroirac.NodeCollection nodeCollection3 = new graph_toanroirac.NodeCollection();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearEdge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangeNodeColor = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.chkUndirectedGrapth = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.graphUI1 = new graph_toanroirac.GraphUI();
            this.btnDeleteLastestEdge = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 50);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Toolbox";
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
            this.toolStrip1.Size = new System.Drawing.Size(232, 25);
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
            this.panel1.Controls.Add(this.btnDeleteLastestEdge);
            this.panel1.Controls.Add(this.btnClearEdge);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkUndirectedGrapth);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(15, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 360);
            this.panel1.TabIndex = 11;
            // 
            // btnClearEdge
            // 
            this.btnClearEdge.Location = new System.Drawing.Point(52, 6);
            this.btnClearEdge.Name = "btnClearEdge";
            this.btnClearEdge.Size = new System.Drawing.Size(115, 32);
            this.btnClearEdge.TabIndex = 11;
            this.btnClearEdge.Text = "Clear Edges";
            this.btnClearEdge.UseVisualStyleBackColor = true;
            this.btnClearEdge.Click += new System.EventHandler(this.btnClearEdge_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeNodeColor);
            this.groupBox1.Controls.Add(this.btnDeleteNode);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(42, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 104);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Options";
            // 
            // btnChangeNodeColor
            // 
            this.btnChangeNodeColor.Location = new System.Drawing.Point(14, 67);
            this.btnChangeNodeColor.Name = "btnChangeNodeColor";
            this.btnChangeNodeColor.Size = new System.Drawing.Size(98, 25);
            this.btnChangeNodeColor.TabIndex = 1;
            this.btnChangeNodeColor.Text = "Change Color";
            this.btnChangeNodeColor.UseVisualStyleBackColor = true;
            this.btnChangeNodeColor.Click += new System.EventHandler(this.btnChangeNodeColor_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(14, 30);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(97, 25);
            this.btnDeleteNode.TabIndex = 0;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // chkUndirectedGrapth
            // 
            this.chkUndirectedGrapth.Location = new System.Drawing.Point(51, 116);
            this.chkUndirectedGrapth.Name = "chkUndirectedGrapth";
            this.chkUndirectedGrapth.Size = new System.Drawing.Size(118, 20);
            this.chkUndirectedGrapth.TabIndex = 8;
            this.chkUndirectedGrapth.Text = "Undirected Graph";
            this.chkUndirectedGrapth.UseVisualStyleBackColor = true;
            this.chkUndirectedGrapth.CheckedChanged += new System.EventHandler(this.chkUndirectedGrapth_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // graphUI1
            // 
            this.graphUI1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            edgeCollection3.SelectedIndex = 0;
            graph3.edgeCollection = edgeCollection3;
            nodeCollection3.SelectedIndex = 0;
            graph3.nodeCollection = nodeCollection3;
            this.graphUI1.Data = graph3;
            this.graphUI1.IsUndirectedGraph = false;
            this.graphUI1.Location = new System.Drawing.Point(250, 12);
            this.graphUI1.Name = "graphUI1";
            this.graphUI1.Size = new System.Drawing.Size(489, 416);
            this.graphUI1.TabIndex = 0;
            this.graphUI1.Text = "graphUI1";
            this.graphUI1.SelectedNodeChanged += new System.EventHandler(this.graphUI1_SelectedNodeChanged);
            // 
            // btnDeleteLastestEdge
            // 
            this.btnDeleteLastestEdge.Location = new System.Drawing.Point(51, 44);
            this.btnDeleteLastestEdge.Name = "btnDeleteLastestEdge";
            this.btnDeleteLastestEdge.Size = new System.Drawing.Size(116, 29);
            this.btnDeleteLastestEdge.TabIndex = 12;
            this.btnDeleteLastestEdge.Text = "Delete Lastest Edge";
            this.btnDeleteLastestEdge.UseVisualStyleBackColor = true;
            this.btnDeleteLastestEdge.Click += new System.EventHandler(this.btnDeleteLastestEdge_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 440);
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
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnChangeNodeColor;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.CheckBox chkUndirectedGrapth;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDeleteLastestEdge;
    }
}