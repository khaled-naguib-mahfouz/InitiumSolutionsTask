using System.ComponentModel.DataAnnotations.Schema;

namespace InitiumSolutionsTask.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        [ForeignKey(nameof(HotelBranch))]

        public int BranchId { get; set; }
        public string RoomNumber { get; set; }

        // Navigation Properties
        public RoomType RoomType { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
