using System.ComponentModel.DataAnnotations.Schema;

namespace InitiumSolutionsTask.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(HotelBranch))]
        public int BranchId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; }
        public double DiscountApplied { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
