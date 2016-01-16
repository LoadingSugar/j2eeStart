using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using System.Data.SqlClient;
namespace Bank
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        public static DBview dbv = new DBview();
        private void mainForm_Load(object sender, EventArgs e)
        {

            
            dbv.MdiParent = this;
            dbv.ClientSize = ClientSize;
            dbv.Show();
            if (Login.check1) {
                Login.check1 = false;
                this.管理员操作ToolStripMenuItem.Visible = false;
                this.toolStripButton5.Visible = false;
                this.toolStripButton6.Visible = false;
                this.toolStripButton7.Visible = false;
                this.toolStripButton8.Visible = false;
                
            }else {
                this.账户管理ToolStripMenuItem.Visible = false;
                this.toolStripButton1.Visible = false;
                this.toolStripButton2.Visible = false;
                this.toolStripButton3.Visible = false;
                this.toolStripButton4.Visible = false;
                this.toolStripButton10.Visible = false;

            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            
            string bank_id = Login.dt.Tables[0].Rows[0][3].ToString();
            Control.Control control = new Control.Control();
            dbv.dgv.DataSource = control.getBank(bank_id);
            dbv.dgv.DataMember = "bank";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string customer_id = Login.dt.Tables[0].Rows[0][0].ToString();
            Control.Control control = new Control.Control();
            dbv.dgv.DataSource =control.getBill(customer_id); 
            dbv.dgv.DataMember = "bill";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string customer_id = Login.dt.Tables[0].Rows[0][0].ToString ();
            Control.Control control = new Control.Control();
            int affected = control.AddBill(customer_id);
            if (affected == 1)
            {
                MessageBox.Show("添加账单成功");
            }
            else {
                MessageBox.Show("添加账单失败");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DrawAndDeposit dad = new DrawAndDeposit();
            dad.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ChangePassword ch = new ChangePassword();
            ch.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DeleteCustomer delete = new DeleteCustomer();
            delete.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            UpdateCustomer up = new UpdateCustomer();
            up.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
            Control.Control control = new Control.Control();
            dbv.dgv.DataSource = control.getAllCustomer ();
            dbv.dgv.DataMember = "allcustomer";
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本v1.0");
        }

        private void 账户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.toolStripButton1.Checked = true;
        }

        private void 申请账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.toolStripButton2.Checked = true;
        }

        private void 存取业务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton3.Checked = true;
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton4.Checked = true;
        }

        private void 账户添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton5.Checked = true;
        }

        private void 删除户主ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton6.Checked = true;
        }

        private void 更新户主信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton7.Checked = true;
        }

        private void 查询户主ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton8.Checked = true;
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton9.Checked = true;
        }

        private void 查看银行信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton10.Checked = true;
        }

        

        

       

        
    }
}
