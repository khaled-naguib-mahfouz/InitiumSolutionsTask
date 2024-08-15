using System.ComponentModel.DataAnnotations;

namespace InitiumSolutionsTask.ViewModel
{
    public class RoomBookingViewModel
    {
        [Required]
        
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        public string RoomType { get; set; }
        public Room Room { get; set; }
    }

}
