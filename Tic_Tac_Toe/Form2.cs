using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.set_name(t1.Text, t2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.set_pc(t1.Text);
            this.Close();
        }

       
    }
}
