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
    public partial class LoginManager : Form
    {
        
        public LoginManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.dbv.dgv.DataSource = null;
            bool m_check;
            Control.Control control = new Control.Control();
            Entity.Entity entity = new Entity.Entity();
            entity.setM_Username(this.textBox1.Text);
            entity.setM_Password(this.textBox2.Text);
            m_check = control.checkM_Users(entity.getM_Username(), entity.getM_Password());
            
            if (m_check)
            {
                
                this.Visible = false;
                mainForm main = new mainForm();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                MessageBox.Show("密码错误或管理员不存在");
            }
             
        }

        private void LoginManager_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
