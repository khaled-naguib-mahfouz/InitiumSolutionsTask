using System.ComponentModel.DataAnnotations;

namespace InitiumSolutionsTask.Models
{
    public class HotelBranch
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }

        // Navigation Property
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}

