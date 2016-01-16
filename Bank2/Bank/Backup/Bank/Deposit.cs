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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.Control control = new Control.Control();
            int billid = control.current(mainForm.dbv.dgv);
            if (billid != 0)
            {
                int affected = control.Deposit(billid, Convert.ToInt32(this.textBox1.Text));
                bool time = control.time (billid);
                if (time && affected == 1)
                {
                    MessageBox.Show("存款成功");
                }
                else
                {
                    MessageBox.Show("存款失败");
                }
            }
            else
            {
                MessageBox.Show("请选择存款账单");
            }
        }
    }
}
