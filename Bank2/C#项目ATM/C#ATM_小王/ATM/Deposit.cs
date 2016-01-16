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
    public partial class Deposit : Form
    {
        Choose cho;
        public Deposit(Choose c)
        {
            InitializeComponent();
            cho = c;
        }

        private void sure_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(m_money.Text) <= 0)
            {
                MessageBox.Show("存款金额必须大于零！");
                return;
            }
            if ((Convert.ToDouble(m_money.Text))%100.0!=0)
            {
                MessageBox.Show("存钱必须是100整数倍");
                return;
             } 
            cho.m_user.Money += Convert.ToDouble(m_money.Text);
            Operator op=new Operator();
            op.type ="存款";
            op.M_account = cho.m_user.Account;
            op.M_money = Convert.ToDouble(m_money.Text);
            op.m_time = DateTime.Now.ToString();
            textBox1.Text = DateTime.Now.ToString();
            Program.operato.Add(op);
       
            MessageBox.Show("存款成功！");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("返回上一级");
            this.Hide();
        }
    }
}
