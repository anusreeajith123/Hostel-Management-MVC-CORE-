using HostelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;


namespace HostelManagement.Models
{
    public class RoomDAL
    {


        string conString =
        "Server=ANUSREE;Database=COREproject;Integrated Security=True;TrustServerCertificate=True;";


        // Insert Room
        public int InsertRoom(Room obj)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand("sp_InsertRoom", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@RoomNo", obj.RoomNo);
            cmd.Parameters.AddWithValue("@RoomType", obj.RoomType);
            cmd.Parameters.AddWithValue("@Capacity", obj.Capacity);
            cmd.Parameters.AddWithValue("@Status", obj.Status);


            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }




        // Room List
        public List<Room> GetRooms()
        {

            List<Room> list = new List<Room>();

            SqlConnection con = new SqlConnection(conString);


            SqlCommand cmd = new SqlCommand("sp_GetRooms", con);

            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {

                Room rm = new Room();

                rm.Room_id = Convert.ToInt32(dr["Room_id"]);

                rm.RoomNo = Convert.ToInt32(dr["Room_no"]);

                rm.RoomType = dr["Room_Type"].ToString();

                rm.Capacity = Convert.ToInt32(dr["Capacity"]);

                rm.Status = dr["Status"].ToString();


                list.Add(rm);

            }


            con.Close();

            return list;

        }





        // Get Room By Id
        public Room GetRoomById(int id)
        {

            Room rm = new Room();


            SqlConnection con = new SqlConnection(conString);


            SqlCommand cmd = new SqlCommand("sp_GetRoomById", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Room_id", id);



            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();



            if (dr.Read())
            {

                rm.Room_id = Convert.ToInt32(dr["Room_id"]);

                rm.RoomNo = Convert.ToInt32(dr["Room_no"]);

                rm.RoomType = dr["Room_Type"].ToString();

                rm.Capacity = Convert.ToInt32(dr["Capacity"]);

                rm.Status = dr["Status"].ToString();

            }


            con.Close();


            return rm;

        }






        // Update Room
        public int UpdateRoom(Room rm)
        {

            SqlConnection con = new SqlConnection(conString);


            SqlCommand cmd = new SqlCommand("sp_UpdateRoom", con);

            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@Room_id", rm.Room_id);

            cmd.Parameters.AddWithValue("@RoomNo", rm.RoomNo);

            cmd.Parameters.AddWithValue("@RoomType", rm.RoomType);

            cmd.Parameters.AddWithValue("@Capacity", rm.Capacity);

            cmd.Parameters.AddWithValue("@Status", rm.Status);



            con.Open();


            int i = cmd.ExecuteNonQuery();


            con.Close();


            return i;

        }






        // Delete Room
        public int DeleteRoom(int id)
        {

            SqlConnection con = new SqlConnection(conString);


            SqlCommand cmd = new SqlCommand("sp_DeleteRoom", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Room_id", id);



            con.Open();


            int i = cmd.ExecuteNonQuery();


            con.Close();


            return i;

        }

    }
}






