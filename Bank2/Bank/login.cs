using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace bank
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string pword = this.textBox2.Text;
            if (username.Length != 0 && pword.Length != 0)
            {
                string cs = "Data Source=.;Initial Catalog=bankDB;Integrated Security=Ture";
                string sql = "select count(*)from cardinfo where cardID="+username+"and password="+pword+"";
                SqlConnection a = new SqlConnection(cs);
                a.Open();
                SqlCommand cmd = new SqlCommand(sql,a);
                int abc = Convert.ToInt32(cmd.ExecuteScalar());
                if (abc==1)
                {
                    this.Hide();
                    bankmenu z = new bankmenu();
                    z.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
            }
            else
            {
                MessageBox.Show("请输入值");
            }
        }
    }
}
