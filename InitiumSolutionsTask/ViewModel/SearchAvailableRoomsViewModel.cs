using System.ComponentModel.DataAnnotations;

namespace InitiumSolutionsTask.ViewModel
{
    public class SearchAvailableRoomsViewModel
    {
        [Required]
        [Display(Name = "Check-In Date")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check-Out Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

    }
}
