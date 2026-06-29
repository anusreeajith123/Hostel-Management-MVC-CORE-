using Microsoft.Data.SqlClient;
using System.Data;
namespace HostelManagement.Models
{
    public class StudentDAL
    {
        DBConnection db = new DBConnection();

        // Insert Student
        public int InsertStudent(Student obj)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertStudent", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentName", obj.StudentName);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Course", obj.Course);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);

            db.con.Open();

            int i = cmd.ExecuteNonQuery();

            db.con.Close();

            return i;
        }

        // Student List
        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();

            SqlCommand cmd = new SqlCommand("sp_GetStudents", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            db.con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Student st = new Student();

                st.Student_id = Convert.ToInt32(dr["Student_id"]);
                st.StudentName = dr["StudentName"].ToString();
                st.Gender = dr["Gender"].ToString();
                st.Course = dr["Course"].ToString();
                st.Phone = Convert.ToInt64(dr["Phone"]);

                list.Add(st);
            }

            db.con.Close();

            return list;
        }

        // Get Student By Id
        public Student GetStudentById(int id)
        {
            Student st = new Student();

            SqlCommand cmd = new SqlCommand("sp_GetStudentById", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_id", id);

            db.con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                st.Student_id = Convert.ToInt32(dr["Student_id"]);
                st.StudentName = dr["StudentName"].ToString();
                st.Gender = dr["Gender"].ToString();
                st.Course = dr["Course"].ToString();
                st.Phone = Convert.ToInt64(dr["Phone"]);
            }

            db.con.Close();

            return st;
        }

        // Update Student
        public int UpdateStudent(Student obj)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateStudent", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_id", obj.Student_id);
            cmd.Parameters.AddWithValue("@StudentName", obj.StudentName);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Course", obj.Course);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);

            db.con.Open();

            int i = cmd.ExecuteNonQuery();

            db.con.Close();

            return i;
        }
        public int DeleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteStudent", db.con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_id", id);


            db.con.Open();

            int i = cmd.ExecuteNonQuery();

            db.con.Close();

            return i;
        }
    }
}
