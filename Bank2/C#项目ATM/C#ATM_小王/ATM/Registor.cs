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
    public partial class Registor : Form
    {
        public Registor()
        {
            InitializeComponent();
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            foreach (UserInfo user in Program.users)
            {
                if (account.Text == user.Account)
                {
                    MessageBox.Show("帐号存在，请重新输入");
                    return;
                }
                if (account.Text.Length != 16)
                {
                    lable1.Text = "帐号必须为16位";
                    return;
                }
                if (account.Text == String.Empty)//|| Convert.ToInt32(account.Text) < 0)
                {
                    MessageBox.Show("此帐号不能为空,而且不能为负数");
                    return;
                }
            }

            if (pass1.Text.Length!=6)
            {
                label5.Text = "密码长度必须为6位";
                return;
            }

            if (pass1.Text != pass2.Text)
            {
                label6.Text = "两次输入的密码不一致";
                return;
            }

            else
            {
                UserInfo user = new UserInfo();
                user.Account = account.Text;
                user.Name = name.Text;
                user.Pass = pass1.Text;
                user.Money = 0;
                Program.users.Add(user);
                MessageBox.Show("注册成功!");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
