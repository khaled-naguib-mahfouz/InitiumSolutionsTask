using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InitiumSolutionsTask.ViewModel
{
    public class BookingViewModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "National ID")]
        public string NationalId { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Hotel Branch")]
        public int BranchId { get; set; }
        [Required]
        [Display(Name = "Rooms Available")]
        public int RoomId { get; set; }


        [Required]
        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }
        [Display(Name ="Branches")]

        public IEnumerable<HotelBranch> Branches { get; set; }= new List<HotelBranch>();

        public List<RoomBookingViewModel> RoomBookings { get; set; } = new List<RoomBookingViewModel>();
    }
}
