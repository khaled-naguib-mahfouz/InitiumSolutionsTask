using InitiumSolutionsTask.Models;
using InitiumSolutionsTask.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitiumSolutionsTask.ViewModel;

namespace InitiumSolutionsTask.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IBookingService _bookingService;
        private readonly IHotelBranchService _hotelBranchService;
        public BookingController(IHotelBranchService hotelBranchService
            ,IBookingService bookingService,
IRoomTypeService roomTypeService)
        {
            _bookingService = bookingService;
            _hotelBranchService = hotelBranchService;
            _roomTypeService = roomTypeService;
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
            var roomTypes = _roomTypeService.GetAllRoomTypes()
                                    .Select(rt => new SelectListItem
                                    {
                                        Value = rt.RoomTypeId.ToString(),
                                        Text = rt.TypeName
                                    }).ToList();
            var model = new BookingViewModel
            {
                Branches = await _hotelBranchService.GetAllBranchesAsync(),
                RoomBookings = new List<RoomBookingViewModel> { new RoomBookingViewModel( roomTypes

                   ) }
                     
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
       

            return View(bookingViewModel);
        }
    }
}
