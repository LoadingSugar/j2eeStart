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
    public partial class Draw : Form
    {
        public Draw()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Control.Control control = new Control.Control();
            int billid = control.current(mainForm.dbv.dgv);
            if (billid != 0)
            {
                bool check = control.judge(Convert.ToInt32(this.textBox1.Text), mainForm.dbv.dgv);
                if(check)
                {
                    int affected = control.Draw(billid, Convert.ToInt32(this.textBox1.Text));
                    if (affected == 1)
                    {
                       MessageBox.Show("取款成功");
                    }
                    else
                    {
                      MessageBox.Show("取款失败");
                    }
                }
                else
                {
                    MessageBox.Show("余额不足");
                }
            }
            else 
            {
                MessageBox.Show("请选择取款账单");
            }
        }

       
    }
}
