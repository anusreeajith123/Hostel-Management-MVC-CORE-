using Microsoft.Data.SqlClient;
using System.Data;


namespace HostelManagement.Models
{
    public class LoginDAL
    {
        DBConnection db = new DBConnection();
        public bool AdminLogin(Admin obj)
        {
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);

            db.con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                db.con.Close();
                return true;
            }
            else
            {
                db.con.Close();
                return false;
            }
        }
    }
}
