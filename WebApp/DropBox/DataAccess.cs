using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DropBox
{
    public class DataAccess
    {
        public static Exception SaveData(string querry)
        {
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static DataSet FetchData(string querry)
        {
            DataSet Ds = new DataSet();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(querry, con);
            da.Fill(Ds);
            con.Close();
            return Ds;
        }
    }
}