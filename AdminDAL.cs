using Microsoft.Data.SqlClient;
using System.Data;

namespace HostelManagement.Models
{
    public class AdminDAL
    {
        DBConnection db = new DBConnection();

        public int AdminRegister(Admin obj)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertAdmin", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);

            db.con.Open();

            int i = cmd.ExecuteNonQuery();

            db.con.Close();

            return i;
        }

        public bool AdminLogin(Admin obj)
        {
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);

            db.con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            bool status = dr.Read();

            db.con.Close();

            return status;
        }
    }

}

