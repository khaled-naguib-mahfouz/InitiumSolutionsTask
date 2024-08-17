namespace InitiumSolutionsTask.Models
{
    public class RoomBooking
    {
        public int RoomBookingId { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }

        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        // Navigation Properties
        public Booking Booking { get; set; }
        public Room Room { get; set; }
        public RoomType RoomType { get; set; }
    }
}
