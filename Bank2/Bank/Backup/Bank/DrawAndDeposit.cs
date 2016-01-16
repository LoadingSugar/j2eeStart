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
    public partial class DrawAndDeposit : Form
    {
        public DrawAndDeposit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw dr = new Draw();
            dr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposit de = new Deposit();
            de.ShowDialog();
        }
    }
}
