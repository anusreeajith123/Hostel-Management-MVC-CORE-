namespace HostelManagement.Models
{
    public class Allocation
    {
        public int Allocation_id { get; set; }

        public int Student_id { get; set; }

        public int Room_id { get; set; }

        public string? StudentName { get; set; }

        public string? RoomNo { get; set; }

        public DateTime AllocationDate { get; set; }

    }
}
