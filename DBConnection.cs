using Microsoft.Data.SqlClient;

namespace HostelManagement.Models
{
    public class DBConnection
    {
        public SqlConnection con = new SqlConnection("Server=ANUSREE;Database=COREproject;Integrated Security=True;TrustServerCertificate=True;");
    }
}
