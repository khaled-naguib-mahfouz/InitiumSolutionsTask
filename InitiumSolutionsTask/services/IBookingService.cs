
namespace InitiumSolutionsTask.services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
       Task CreateBookingAsync( BookingViewModel bookingViewModel);
        Task<Booking> GetBookingDetailsAsync(int bookingId);
    }
}
