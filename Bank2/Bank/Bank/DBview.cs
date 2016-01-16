using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bank
{
    public partial class DBview : Form
    {

        public DBview()
        {
            InitializeComponent();
        }

        private  void DBview_Load(object sender, EventArgs e)
        {

            BindingSource bindingSource1 = new BindingSource();
            this.dgv.DataSource = Login.dt.Tables["customer"];
        }

        
        
    }
}
