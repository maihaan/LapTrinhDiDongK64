using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MyCalendar.Controllers
{
    public class DataAccess
    {
        String sqlConnectioString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
        public DataTable Doc(String query)
        {
            SqlConnection con = new SqlConnection(sqlConnectioString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
                return tb;
            }
            catch
            {
                return null;
            }
        }

        public int Ghi(String query)
        {
            SqlConnection con = new SqlConnection(sqlConnectioString);
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                int dem = cmd.ExecuteNonQuery();
                con.Close();
                return dem;
            }
            catch
            {
                return -2;
            }
        }
    }
}