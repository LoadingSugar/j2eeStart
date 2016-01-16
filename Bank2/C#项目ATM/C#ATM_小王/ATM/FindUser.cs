using System;
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
    public partial class FindUser : Form
    {
        UserInfo use = new UserInfo();
        Choose ch=new Choose();
        public FindUser(Choose chos)
        {
            ch = chos;
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        { 
            use = ch.m_user;
            m_Name.Text = ch.m_user.Name;
            money1.Text = Convert.ToString(ch.m_user.Money);
        }

        private void return_click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
