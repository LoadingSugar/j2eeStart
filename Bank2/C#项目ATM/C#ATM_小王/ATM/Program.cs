using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ATM
{
    static class Program
    {
        public static List<UserInfo> users=new List<UserInfo>();
        public static List<Operator> operato = new List<Operator>();
        public static void Write()
        {
            FileStream file = new FileStream(@"operator.txt", FileMode.OpenOrCreate);
            StreamWriter writ = new StreamWriter(file);
            foreach (Operator op in Program.operato)
            {
                writ.WriteLine(op.type);
                writ.WriteLine(op.M_account);
                writ.WriteLine(op.M_money);
                writ.WriteLine(op.m_time);
                
            }
            writ.Close();
        }

        public static void Read()
        {
            FileStream file = new FileStream(@"operator.txt", FileMode.OpenOrCreate);
            StreamReader Read = new StreamReader(file);
            Operator ope = null;
            while (!Read.EndOfStream)
            {
                ope = new Operator();
                ope.type = Read.ReadLine();
                ope.M_account = Read.ReadLine();
                ope.M_money = Convert.ToDouble(Read.ReadLine());
                ope.m_time = Read.ReadLine();
                operato.Add(ope);
            }
            Read.Close();
        }


        public static void WriteDoc()
        {
            FileStream file1 = new FileStream(@"user.txt", FileMode.OpenOrCreate);
            StreamWriter write1 = new StreamWriter(file1);
            foreach (UserInfo user1 in Program.users)
            { 
                write1.WriteLine(user1.Account);
                write1.WriteLine(user1.Name);
                write1.WriteLine(user1.Pass);
                write1.WriteLine(user1.Money);
            }
           write1.Close();
        }


        public static void ReadDoc()
        {
            FileStream file1 = new FileStream(@"user.txt", FileMode.OpenOrCreate);
            StreamReader Read1 = new StreamReader(file1);
            UserInfo user = null;
            while (!Read1.EndOfStream)
            {
                user = new UserInfo();
                user.Account = Read1.ReadLine();
                user.Name = Read1.ReadLine();
                user.Pass = Read1.ReadLine();
                user.Money = Convert.ToDouble(Read1.ReadLine());
                users.Add(user);
            }
            Read1.Close();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Read();
            ReadDoc();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            WriteDoc();
            Write();
        }
    }
}
