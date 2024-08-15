using InitiumSolutionsTask.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InitiumSolutionsTask.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IHotelBranchService _hotelBranchService;
        public BookingController(IHotelBranchService hotelBranchService
            ,IBookingService bookingService)
        {
            _bookingService = bookingService;
            _hotelBranchService = hotelBranchService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingDetailsAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        public async Task<IActionResult> Index()
        {
            // Get the list of bookings from the service
            var bookings = _bookingService.GetAllBookings();

            // Pass the bookings list to the view
            return View(bookings);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new BookingViewModel
            {
                Branches = await _hotelBranchService.GetAllBranchesAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookingService.CreateBookingAsync(bookingViewModel);
                    TempData["SuccessMessage"] = "Booking created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    ModelState.AddModelError("", $"An error occurred while creating the booking: {ex.Message}");
                }
            }
       

            // If model state is invalid or an error occurred, re-display the form
            return View(bookingViewModel);
        }
    }
}
