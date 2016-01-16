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
    
    public partial class Choose : Form
    {
        Login form = new Login();
        public UserInfo m_user;
        public Choose()
        {
            InitializeComponent();
            m_user = new UserInfo();
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit(this);
            deposit.ShowDialog(); 
        }
        public void SetUser(UserInfo user)
        {
            m_user = user;
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Draw draw = new Draw(this);
            draw.ShowDialog();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            FindUser find = new FindUser(this);
            find.ShowDialog();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            Transfer tran = new Transfer(this);
            tran.ShowDialog();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
            form.ShowDialog();
        }

        private void Find_Time_Click(object sender, EventArgs e)
        {
            Time_Fine time = new Time_Fine(this);
            time.ShowDialog();
        }
    }
}
