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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            weight = 1;
            textBox1.Text = weight.ToString();
        }
        public int weight
        {
            get
            {
                return int.Parse(textBox1.Text);
            }
            set
            {
                textBox1.Text = value.ToString();
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            weight = 0;
            this.Close();
        }
    }
}
