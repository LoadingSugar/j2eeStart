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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.Control control = new Control.Control();
            int affected = control.addCustomer (this.textBox1 .Text ,this.textBox2 .Text ,this.textBox3 .Text ,this.textBox4 .Text );
            if (affected == 1)
            {
                MessageBox.Show("添加成功");

            }
            else 
            {
                MessageBox.Show("添加失败");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            this.textBox3.PasswordChar = '*';
        }
    }
}
