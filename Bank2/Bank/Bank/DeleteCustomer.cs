using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank
{
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.Control control = new Control.Control();
            int affected=control.delete(this.textBox1.Text);
            if (affected != 0)
            {
                MessageBox.Show("删除成功");
            }
            else 
            {
                MessageBox.Show("删除失败");
                this.textBox1.Text = "";
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
