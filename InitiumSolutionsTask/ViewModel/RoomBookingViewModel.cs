using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InitiumSolutionsTask.ViewModel
{
    public class RoomBookingViewModel
    {
        [Required]
        
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }

        [Required]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = new List<SelectListItem>();
        public Room Room { get; set; }
        // Default constructor
        public RoomBookingViewModel()
        {
        }

        // Constructor with parameters (optional)
        public RoomBookingViewModel(IEnumerable<SelectListItem> roomTypes)
        {
            RoomTypes = roomTypes;
        }
    }

}
