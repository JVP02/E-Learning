using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameProject
{
    internal class DBConnection
    {
        public SqlConnection Con;

        public void Connection()
        {
            Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liam\\source\\repos\\TheGameProject\\GDB.mdf;Integrated Security=True;Connect Timeout=30");

        }
    }
}
