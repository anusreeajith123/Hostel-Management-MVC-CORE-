namespace HostelManagement.Models
{
    public class Room
    {
        public int Room_id { get; set; }
        public int RoomNo { get; set; }
        public string? RoomType { get; set; }
        public int Capacity { get; set; }
        public string? Status { get; set; }
    }
}
