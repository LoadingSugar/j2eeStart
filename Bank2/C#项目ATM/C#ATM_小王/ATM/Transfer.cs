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
    public partial class Transfer : Form
    {
        Choose chos;
        public Transfer(Choose cho)
        {
            chos = cho;
            InitializeComponent();
        }

        //public static string Account = "";
        private void Transfer_OK_Click(object sender, EventArgs e)
        {
            foreach (UserInfo user1 in Program.users)
            {
                if (Transfer_account.Text == user1.Account)
                {
                   // Account = Transfer_account.Text;
                    if (chos.m_user.Money <= Convert.ToDouble(Transfer_money.Text)) 
                    {
                        MessageBox.Show("余额不足！");
                        return;
                    }
                      
                    else if (Convert.ToDouble(Transfer_money.Text)<=0)
                    {
                        MessageBox.Show("输入的转账金额不能为负数");
                        return;
                    }
                    else
                    {
                        chos.m_user.Money -= Convert.ToDouble(Transfer_money.Text);
                        Operator op = new Operator(); 
                        op.type="转账";
                        op.M_account=Transfer_account.Text;
                        op.M_money=Convert.ToDouble(Transfer_money.Text);
                        op.m_time=DateTime.Now.ToString();
                        Program.operato.Add(op);
                        user1.Money += Convert.ToDouble(Transfer_money.Text);
                        MessageBox.Show("转账成功！");
                        return;
                    }
                }
           }
            MessageBox.Show("此帐号不存在");
            return;
        }

        private void button1_return_click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
