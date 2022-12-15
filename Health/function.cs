 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Health
{
    class function
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTaple dt;
        private sqlDataAdaper sda;
        private string Constr;

        public function()
        {
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fg\Documents\HealthCareDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(Constr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTaple();
            sda = new sqlDataAdaper(Query, con);
            sda.Fill(dt);
            return dt;
        }
        public int setData (string Query)
        {
            int Cnt = 0;
            if (con.state == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            return Cnt;
        }
    }
}
