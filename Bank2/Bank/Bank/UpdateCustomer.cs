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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar ='*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.Control control = new Control.Control();
            string customer_id = control.currentC(mainForm.dbv.dgv);
            if (customer_id != "")
            {
                int affected = control.update(customer_id, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                if (affected == 1)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");

                }
            }
            else 
            {
                MessageBox.Show("请选择要修改的用户记录");
 
            
            }
            
        }
    }
}
