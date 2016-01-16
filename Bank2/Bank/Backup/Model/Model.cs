using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Model
{
    
    public class Model
    {
        public string strConn = @"Data Source=ONIL-PC\SQLEXPRESS;Initial Catalog=Bank;Persist Security Info=True;User ID=sa;Password=1988fz71";
        public string strConn1 = @"Data Source=ONIL-PC\SQLEXPRESS;Initial Catalog=Bank;Persist Security Info=True;User ID=sa;Password=1988fz71";
        public string strConn2 = @"Data Source=ONIL-PC\SQLEXPRESS;Initial Catalog=Bank;Persist Security Info=True;User ID=sa;Password=1988fz71";
        //获取账户信息
        public string getUserInfor(string username) {
            string strCom = "select password from customer where cname=@cname";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            da.SelectCommand.Parameters.AddWithValue("@cname", username);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count==0)
            {
                return "0";
            }
            else {
                return dt.Rows[0][0].ToString();
            }
        }
        //获取管理员信息
        public string getM_UserInfor(string m_username)
        {
            string strCom = "select password from admin where username=@username";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            da.SelectCommand.Parameters.AddWithValue("@username", m_username);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return "0";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }
        //获取账户信息
        public DataSet getCustomerInfor(string username)
        {
            string strCom = "select * from customer where cname=@cname";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            da.SelectCommand.Parameters.AddWithValue("@cname", username);
            DataSet dt = new DataSet();
            da.Fill(dt, "customer");
            return dt;
        }
        //获取银行信息
        public DataSet getBankInfor(string bank_id){
            string strCom = "select * from bank where bankid=@bankid";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            da.SelectCommand.Parameters.AddWithValue("@bankid", bank_id );
            DataSet dt = new DataSet();
            da.Fill(dt, "bank");
            return dt;
        
        }
        //获取账单
        public DataSet getBillInfor(string customer_id) {
            string strCom = "select * from fund_bill where customer_id=@customer_id";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            da.SelectCommand.Parameters.AddWithValue("@customer_id", customer_id);
            DataSet dt = new DataSet();
            da.Fill(dt, "bill");
            return dt;
        }
        //添加账单
        public int addBillInfor(string customer_id)
        {
            string strCom = "insert into [fund_bill](customer_id) values(@customer_id)";
            
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(strCom,cn);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            int affected=cmd.ExecuteNonQuery();
            return affected;
        }
        //用户取款
        public int drawMoney(int billid, int fortune_amount)
        {
            string strCom = "update [fund_bill] set fortune_amount=fortune_amount-@fortune_amount where billid=@billid";
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(strCom, cn);
            cmd.Parameters.AddWithValue("@billid", billid);
            cmd.Parameters.AddWithValue("@fortune_amount", fortune_amount);
            int affected = cmd.ExecuteNonQuery();
            return affected;
        }
        //用户当前账单
        public int currentRecord(DataGridView dgv) 
        {
            if (dgv.DataMember == "bill")
            {
                DataRow dr = ((DataRowView)dgv.BindingContext[dgv.DataSource, "bill"].Current).Row;
                return (int)dr[0];
            }
            return 0;
            
            
        }
        //判断余额
        public int judgeMoney(int money, DataGridView dgv) 
        { 
           DataRow dr = ((DataRowView)dgv.BindingContext[dgv.DataSource, "bill"].Current).Row;
           if (money > (int)dr[1])
           {
               return 0;
           }
           else 
           {
               return 1;
           }
        }
        //用户存款
        public int depositMoney(int billid, int fortune_amount)
        {
            string strCom = "update [fund_bill] set fortune_amount=fortune_amount+@fortune_amount where billid=@billid";
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(strCom, cn);
            cmd.Parameters.AddWithValue("@billid", billid);
            cmd.Parameters.AddWithValue("@fortune_amount", fortune_amount);
            int affected = cmd.ExecuteNonQuery();
            return affected;
        }
        //更新存款时间
        public int depositTime(int billid)
        {
            string strCom = "update [fund_bill] set deposite_date=@deposite_date where billid=@billid";
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(strCom, cn);
            cmd.Parameters.AddWithValue("@billid", billid);
            cmd.Parameters.AddWithValue("@deposite_date", DateTime.Today);
            int affected = cmd.ExecuteNonQuery();
            return affected;
        }
        //更改用户密码
        public int changePassword(string  customer_id,string password)
        {
            string strCom = "update [customer] set password=@password where customer_id=@customer_id";
            SqlConnection cn = new SqlConnection(strConn);
            cn.Open();
            SqlCommand cmd = new SqlCommand(strCom, cn);
            cmd.Parameters.AddWithValue("@customer_id", customer_id);
            cmd.Parameters.AddWithValue("@password", password);
            int affected = cmd.ExecuteNonQuery();
            return affected;
        }
        //添加用户
        public int addCustomerInfor(string customer_id, string cname, string password, string bankid)
        {
            string strCom1 = "select customer_id from customer where customer_id=@customer_id";
            SqlDataAdapter da1 = new SqlDataAdapter(strCom1, strConn1);
            da1.SelectCommand.Parameters.AddWithValue("@customer_id", customer_id);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            string strCom2 = "select bankid from customer where bankid=@bankid";
            SqlDataAdapter da2 = new SqlDataAdapter(strCom2, strConn2);
            da2.SelectCommand.Parameters.AddWithValue("@bankid", bankid);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt1.Rows.Count == 0 && dt2.Rows.Count != 0)
            {
                string strCom = "insert into [customer] values(@customer_id,@cname,@password,@bankid)";

                SqlConnection cn = new SqlConnection(strConn);
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCom, cn);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@bankid", bankid);
                int affected = cmd.ExecuteNonQuery();
                return affected;
            }
            else 
            {
                return 0;
            
            }
            
            
            
            
        }
        //查询户主
        public DataSet getAllCustomerInfor()
        {
            string strCom = "select * from customer";
            SqlDataAdapter da = new SqlDataAdapter(strCom, strConn);
            DataSet dt = new DataSet();
            da.Fill(dt, "allcustomer");
            return dt;

        }
        //更新户主信息
        public int updateCustomer(string customer_id, string cname, string password, string bankid)
        {
            string strCom2 = "select bankid from customer where bankid=@bankid";
            SqlDataAdapter da2 = new SqlDataAdapter(strCom2, strConn2);
            da2.SelectCommand.Parameters.AddWithValue("@bankid", bankid);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count != 0)
            {
                string strCom = "update [customer] set cname=@cname,password=@password,bankid=@bankid where customer_id=@customer_id";
                SqlConnection cn = new SqlConnection(strConn);
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCom, cn);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@bankid", bankid);
                int affected = cmd.ExecuteNonQuery();
                return affected;
            }
            else {
                return 0;
            }
            
            
        }
        //当前用户信息
        public string  currentC_Record(DataGridView dgv)
        {
            if (dgv.DataMember == "allcustomer")
            {
                DataRow dr = ((DataRowView)dgv.BindingContext[dgv.DataSource, "allcustomer"].Current).Row;
                return dr[0].ToString() ;
            }
            return "0";
        }
        //删除
        public int deleteCustomer(string customer_id)
        {
            string strCom1 = "select customer_id from customer where customer_id=@customer_id";
            SqlDataAdapter da1 = new SqlDataAdapter(strCom1, strConn1);
            da1.SelectCommand.Parameters.AddWithValue("@customer_id", customer_id);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                string strCom = "delete from [customer] where customer_id=@customer_id";
                SqlConnection cn = new SqlConnection(strConn);
                cn.Open();
                SqlCommand cmd = new SqlCommand(strCom, cn);
                cmd.Parameters.AddWithValue("@customer_id", customer_id);
                int affected = cmd.ExecuteNonQuery();
                return affected;
            }
            else 
            {
                return 0;
            
            
            }
            
            
            
        }
        //用户当前存款数
        public int currentM_Record(DataGridView dgv)
        {
            if (dgv.DataMember == "bill")
            {
                DataRow dr = ((DataRowView)dgv.BindingContext[dgv.DataSource, "bill"].Current).Row;
                return (int)dr[1];
            }
            return 0;


        }
        //利息计算
        //public int customerInterest()
        //{
        //    string strCom = "update [fund_bill] set fortune_amount=(fortune_amount+fortune_amount*0.0702)*(@deposite_date-deposite_date)";
        //    string strConn = @"Data Source=ONIL\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True";
        //    SqlConnection cn = new SqlConnection(strConn);
        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand(strCom, cn);
        //    cmd.Parameters.AddWithValue("@billid", billid);
        //    cmd.Parameters.AddWithValue("@fortune_amount", fortune_amount);
        //    int affected = cmd.ExecuteNonQuery();
        //    return affected;
        //}
    }
}
