using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM
{
    public partial class Draw : Form
    {
        Choose ch;
        public Draw(Choose choos)
        {
            ch = choos;
            InitializeComponent();
        }

        private void button100_Click(object sender, EventArgs e)
        { 
            Operator op = new Operator();
            if (ch.m_user.Money <=100)
            {
                MessageBox.Show("余额不足！");
            }
            else
            { 
                ch.m_user.Money -= 100;
                op.type = "取款";
                op.M_account = ch.m_user.Account;
                op.M_money = 100;
                op.m_time = DateTime.Now.ToString();
                Program.operato.Add(op);
                MessageBox.Show("取款成功！");
            }
        }
        
        private void button200_Click(object sender, EventArgs e)
        {

            Operator op = new Operator();
            if (ch.m_user.Money <= 200)
            {
                MessageBox.Show("余额不足！");
            }
            else
            {
                ch.m_user.Money -= 200;
                op.type = "取款";
                op.M_account = ch.m_user.Account;
                op.M_money = 200;
                op.m_time = DateTime.Now.ToString();
                Program.operato.Add(op);
                MessageBox.Show("取款成功！");
            }
        }

        private void button500_Click(object sender, EventArgs e)
        {
            Operator op = new Operator();
            if (ch.m_user.Money <= 500)
            {
                MessageBox.Show("余额不足！");
            }
            else
            {
                ch.m_user.Money -= 500;
                op.type = "取款";
                op.M_account = ch.m_user.Account;
                op.M_money =500;
                op.m_time = DateTime.Now.ToString();    
                Program.operato.Add(op);
                MessageBox.Show("取款成功！");
            }
        }

        private void button1000_Click(object sender, EventArgs e)
        {
            Operator op = new Operator();
            if (ch.m_user.Money <= 1000)
            {
                MessageBox.Show("余额不足！");
            }
            else
            {
                ch.m_user.Money -= 1000;
                op.type = "取款";
                op.M_account = ch.m_user.Account;
                op.M_money = 1000;
                op.m_time = DateTime.Now.ToString();
                Program.operato.Add(op);
                MessageBox.Show("取款成功！");
            }
            
        }

        private void Draw_OK_Click(object sender, EventArgs e)
        {
            Operator op = new Operator();
            if (Convert.ToDouble(money.Text)<=0)
            {
                MessageBox.Show("取款不能为负数！重新输入");
                return;
            }
            if (ch.m_user.Money <= Convert.ToDouble(money.Text))
            {
                MessageBox.Show("余额不足！");
            }
            else
            {
                ch.m_user.Money -= Convert.ToDouble(money.Text);
                op.type = "取款";
                op.M_account = ch.m_user.Account;
                op.M_money = Convert.ToDouble(money.Text);
                op.m_time = DateTime.Now.ToString();
                Program.operato.Add(op);
                MessageBox.Show("取款成功！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
