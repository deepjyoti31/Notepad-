using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_
{
    public partial class UserControl1 : TabPage //UserControl
    {
        public static int counter = 1;

        public UserControl1()
        {
            InitializeComponent();
            t = this.textBox1;
            this.Text = "Tab" + UserControl1.counter;
            UserControl1.counter++;
        }

        public TextBox t;



        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
