using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ATM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
         
        public void SetInfo(UserInfo user)
        {
            user.Account = Account.Text;
            user.Pass = Pass.Text;
        }
        private void Sure_Click(object sender, EventArgs e)
        {
            bool fname = false;
            foreach (UserInfo u in Program.users)
            {
                if (u.Account == Account.Text)
                {
                    fname = true;
                    if (u.Pass == Pass.Text)
                    {
                        MessageBox.Show("登录成功!请选择要执行的操作");
                        Choose chose = new Choose();
                        chose.SetUser(u);
                        chose.ShowDialog();
                        return;
                    }
                }
            }
            if (!fname)
            {     
                if (Account.Text=="")
                {
                    MessageBox.Show("登陆的帐号不能为空！");
                }
                else
                    MessageBox.Show("你输入的帐号不存在,请先注册！");
                return;
            }
            MessageBox.Show("你输入的密码不正确:");

            
        }
        private void Registor_Click(object sender, EventArgs e)
        {
            Registor registor = new Registor();  
            registor.ShowDialog();
        }
    }
}
