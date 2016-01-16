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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.Control control = new Control.Control();
            if (this.textBox1.Text == this.textBox2.Text)
            {
                int affected = control.change(Login.dt.Tables[0].Rows[0][0].ToString(), this.textBox1.Text);
                if (affected == 1)
                {
                    MessageBox.Show("修改密码成功");

                }
                else
                {
                    MessageBox.Show("密码修改失败");

                }
            }
            else 
            {
                MessageBox.Show("重复输入错误");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            this.textBox1.PasswordChar = '*';
            this.textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
