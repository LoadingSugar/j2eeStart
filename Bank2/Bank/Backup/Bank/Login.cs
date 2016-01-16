using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Control;
using Entity;
using System.Data.SqlClient;

namespace Bank
{
    public partial class Login : Form
    {
        public static bool check1;
        public static DataSet dt = new DataSet();
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.textBox2.PasswordChar = '*';
        }

        private void  button1_Click(object sender, EventArgs e)
        {
            
            bool check;
            Control.Control control= new Control.Control();
            Entity.Entity entity = new Entity.Entity();
            entity.setUsername(this.textBox1.Text);
            entity.setPassword(this.textBox2.Text);
            check = control.checkUsers(entity.getUsername(), entity.getPassword());
            dt = control.getCustomer(entity.getUsername());
            if (check)
            {
                check1 = true;
                mainForm main = new mainForm();
                main.ShowDialog();
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }
            else {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                MessageBox.Show("密码错误或用户名不存在");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginManager loginM = new LoginManager();
            loginM.ShowDialog();
        }

        
    }
}
