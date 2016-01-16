using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Entity
    {
        //账户信息数据
        private string username;
        private string password;
        public string getUsername() {
            return username;
        }
        public void  setUsername(string username)
        {
            this.username=username ;
        }
        public string getPassword()
        {
            return password;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }



        //管理员信息数据
        private string m_username;
        private string m_password;
        public string getM_Username()
        {
            return m_username;
        }
        public void setM_Username(string m_username)
        {
            this.m_username = m_username;
        }
        public string getM_Password()
        {
            return m_password;
        }
        public void setM_Password(string m_password)
        {
            this.m_password = m_password;
        }
    }
}
