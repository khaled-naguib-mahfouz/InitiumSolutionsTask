namespace InitiumSolutionsTask.services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customerService;


        public BookingService(ApplicationDbContext context,ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.HotelBranch)
                .Include(b => b.RoomBookings) // Include this if you want to load related RoomBookings
                .ThenInclude(rb => rb.Room)    // Include the Room if needed
                .ThenInclude(r => r.RoomType)  // Include the RoomType if needed
                .ToList();
        }



        public async Task CreateBookingAsync(BookingViewModel bookingViewModel)
        {
            // Retrieve or create customer and determine if the customer is existing
            var (customerId, isExisting) = await _customerService.FindOrCreateCustomerAsync(
                bookingViewModel.NationalId,
                bookingViewModel.CustomerName,
                bookingViewModel.PhoneNumber
            );

            var discount = isExisting ? 0.05 : 0; // 5% discount if existing, otherwise 0%

            var booking = new Booking
            {
                CustomerId = customerId,
                BranchId = bookingViewModel.BranchId,
                CheckInDate = bookingViewModel.CheckInDate,
                CheckOutDate = bookingViewModel.CheckOutDate,
                DiscountApplied = discount // Assuming you have a Discount property in the Booking model
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            foreach (var roomBookingViewModel in bookingViewModel.RoomBookings)
            {
                var roomBooking = new RoomBooking
                {
                    BookingId = booking.BookingId,
                    RoomId = roomBookingViewModel.RoomId,
                    NumberOfAdults = roomBookingViewModel.NumberOfAdults,
                    NumberOfChildren = roomBookingViewModel.NumberOfChildren
                };

                _context.RoomBookings.Add(roomBooking);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<Booking> GetBookingDetailsAsync(int bookingId)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.HotelBranch)
                .Include(b => b.RoomBookings)
                    .ThenInclude(rb => rb.Room)
                    .ThenInclude(r => r.RoomType)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }


    }
}
