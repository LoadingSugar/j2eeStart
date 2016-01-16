using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Operator
    {
        public string type;
        public double M_money;
        public string M_account;
        public string m_time;
    }

    public class UserInfo
    {
        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        private string pass1;

        public string Pass1
        {
            get { return pass1; }
            set { pass1 = value; }
        }
        public string name;

        public string Name
        {
         get { return name; }
         set { name = value; }
        }
        private double money;

        public double Money
        {
            get { return money; }
            set { money = value; }
        }
   
    }
}
