using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_managemant_system
{
    class Database
    {
        private SqlConnection con;
        private SqlCommand cmd;
        SqlDataReader dr;
        public Database()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-C389P13;Initial Catalog=HotelBookingSystemDB;Persist Security Info=True;User ID=admin;Password=admin";
        }
        public void openCon()
        {
            con.Open();
        }
        public void closeCon()
        {
            con.Close();
        }
        public int save_delete_update(string query)
        {
            int row;
            try
            {
                openCon();
            }
            catch
            {
                MessageBox.Show("Please check your database connection");
            }
            cmd = new SqlCommand(query, con);
            row = cmd.ExecuteNonQuery();
            cmd.Dispose();
            closeCon();
            return row;
        }
        public DataTable GetData(string query)
        {
            try
            {
                openCon();
            }
            catch
            {
                MessageBox.Show("Check your database connection");
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closeCon();
            return dt;
        }
        public SqlDataReader DataRead(string query)
        {

            try
            {
                openCon();
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Check your database connection");
            }

            return dr;

        }
    }
}
