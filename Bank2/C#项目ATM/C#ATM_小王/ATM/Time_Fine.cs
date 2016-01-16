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

    public partial class Time_Fine : Form
    {
        Choose cho1 = new Choose();
        public Time_Fine(Choose cho)
        {
            cho1 = cho;
            InitializeComponent();
            showrecord();
        }

        private void Chose_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearshow();
            showrecord();
        }

        private void showrecord()
        {
            switch (Chose.SelectedIndex)
            {
                case 0:
                    foreach (Operator op in Program.operato)
                    {
                        if (op.type == "存款")
                        {
                            if (op.M_account == cho1.m_user.Account)
                            {
                                dataGridView.Rows.Add(op.M_account, op.M_money, op.m_time);
                            }
                        }
                    }
                    break;
                case 1:
                    foreach (Operator op1 in Program.operato)
                    {
                        if (op1.type == "取款")
                        {
                            if (op1.M_account == cho1.m_user.Account)
                            {
                                dataGridView1.Rows.Add(op1.M_account, op1.M_money, op1.m_time);
                            }
                        }

                    }
                    break;
                case 2:
                    foreach (Operator op2 in Program.operato)
                    {
                        if (op2.type=="转账")
                        {
  //                          if (op2.M_account==cho1.m_user.Account)
//                             {
                            dataGridView2.Rows.Add(op2.M_account, op2.M_money, op2.m_time);
//                            }
                        }
                    }
                    break;
            }
        }

        private void showrecond1()
        {
            clearshow();
            foreach(Operator op in Program.operato)
            {
                DateTime dt = DateTime.Parse(op.m_time);
                if (op.M_account == cho1.m_user.Account)
                {
                    if (op.type == "存款")
                    {
                        if (dt >= dateTime1.Value && dt <= dateTime2.Value)
                        {
                            dataGridView.Rows.Add(op.M_account, op.M_money, op.m_time);
                        }
                    }
                    else  if (op.type == "取款")
                    {
                        if (dt >= dateTime1.Value && dt <= dateTime2.Value)
                        {
                            dataGridView1.Rows.Add(op.M_account, op.M_money, op.m_time);
                        }
                    }
                    else if (op.type == "转账")
                    {
                        if (dt >= dateTime1.Value && dt <= dateTime2.Value)
                        {
                            dataGridView2.Rows.Add(op.M_account, op.M_money, op.m_time);
                        }
                    }
                  
                }
            }
        }

        private void clearshow()
        {
            dataGridView.Rows.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void QueryOK_Click(object sender, EventArgs e)
        {
            showrecond1();
        }

        private void dateTime1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
