using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Control
{
    public class Control
    {
        //验证账户
        public  bool checkUsers(string username,string password) {
            Model.Model  model = new Model.Model ();
            string passwd = model.getUserInfor (username);
            if (passwd == "0")
            {
                return false;
            }
            else {
                if (passwd ==password  )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //验证管理员
        public bool checkM_Users(string m_username, string m_password)
        {
            Model.Model model = new Model.Model();
            string m_passwd = model.getM_UserInfor(m_username);
            if (m_passwd == "0")
            {
                return false;
            }
            else
            {
                if (m_passwd == m_password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //获得账户信息
        public DataSet getCustomer(string username)
        {
            Model.Model model = new Model.Model();
            DataSet dt = new DataSet();
            dt = model.getCustomerInfor(username);
            return dt;
        }
        //获取银行信息
        public DataSet getBank(string bank_id) {
            Model.Model model = new Model.Model();
            DataSet dt = new DataSet();
            dt = model.getBankInfor(bank_id);
            return dt;
        }
        //获取账单信息
        public DataSet getBill(string customer_id)
        {
            Model.Model model = new Model.Model();
            DataSet dt = new DataSet();
            dt = model.getBillInfor(customer_id);
            return dt;
        }
        //添加账单
        public int AddBill(string customer_id)
        {
            Model.Model model = new Model.Model();
            int affected = model.addBillInfor(customer_id);
            return affected;
        }
        //用户取款
        public int Draw(int billid, int fortune_amount)
        {
            Model.Model model = new Model.Model();
            int affected = model.drawMoney (billid, fortune_amount);
            return affected;
        }
        //用户当前账单
        public int current(DataGridView dgv)
        {
            Model.Model model = new Model.Model();
            int currentBillid = model.currentRecord(dgv);
            if (currentBillid != 0)
            {
                return currentBillid;
            }
            else 
            {
                return 0;
            }
            
        }
        //判断当前余额
        public bool judge(int money, DataGridView dgv) 
        {
            Model.Model model = new Model.Model();
            int judge=model.judgeMoney(money ,dgv);
            if (judge == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        //用户存款
        public int Deposit(int billid, int fortune_amount)
        {
            Model.Model model = new Model.Model();
            int affected = model.depositMoney(billid, fortune_amount);
            return affected;
        }
        //存款日期
        public bool time(int billid) 
        {
            Model.Model model = new Model.Model();
            int affected = model.depositTime(billid);
            if (affected == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //更改用户密码
        public int change(string customer_id, string password)
        {
            Model.Model model = new Model.Model();
            int affected = model.changePassword(customer_id, password);
            return affected;
        }
        //添加户主信息
        public int addCustomer(string customer_id, string cname, string password, string bankid)
        {
            Model.Model model = new Model.Model();
            int affected = model.addCustomerInfor(customer_id,cname ,password ,bankid );
            return affected;
        }
        //查询户主
        public DataSet getAllCustomer()
        {
            Model.Model model = new Model.Model();
            DataSet dt = new DataSet();
            dt = model.getAllCustomerInfor();
            return dt;
        }
        //户主当前信息
        public string currentC(DataGridView dgv)
        {
            Model.Model model = new Model.Model();
            string  currentC_id = model.currentC_Record(dgv);
            if (currentC_id != "0")
            {
                return currentC_id;
            }
            else
            {
                return "0";
            }

        }
        //更新户主信息
        public int update(string customer_id, string cname, string password, string bankid)
        {
            Model.Model model = new Model.Model();
            int affected = model.updateCustomer (customer_id,cname, password,bankid );
            return affected;
        }
        //删除户主
        public int delete(string customer_id)
        {
            Model.Model model = new Model.Model();
            int affected = model.deleteCustomer (customer_id);
            return affected;
        }
        //利息计算

    }
}
