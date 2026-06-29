using System.Data;
using Microsoft.Data.SqlClient;
using HostelManagement.Models;


namespace HostelManagement.Models
{
    public class AllocationDAL
    {
        string con = "Server=ANUSREE;Database=COREproject;Integrated Security=True;TrustServerCertificate=True;";


        public int InsertAllocation(Allocation obj)
        {
            SqlConnection cn = new SqlConnection(con);

            SqlCommand cmd = new SqlCommand("sp_InsertAllocation", cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_id", obj.Student_id);

            cmd.Parameters.AddWithValue("@Room_id", obj.Room_id);


            cn.Open();

            int i = cmd.ExecuteNonQuery();

            cn.Close();

            return i;
        }



        public List<Allocation> GetAllocation()
        {
            List<Allocation> list = new List<Allocation>();

            SqlConnection cn = new SqlConnection(con);

            SqlCommand cmd = new SqlCommand("sp_GetAllocation", cn);

            cmd.CommandType = CommandType.StoredProcedure;


            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                Allocation a = new Allocation();

                a.Allocation_id = Convert.ToInt32(dr["Allocation_id"]);

                a.StudentName = dr["StudentName"].ToString();

                a.RoomNo = dr["Room_no"].ToString();

                a.AllocationDate = Convert.ToDateTime(dr["AllocationDate"]);


                list.Add(a);
            }


            cn.Close();

            return list;
        }
    }
}
