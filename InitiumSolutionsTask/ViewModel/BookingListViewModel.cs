﻿using System.ComponentModel.DataAnnotations;

namespace InitiumSolutionsTask.ViewModel
{
    public class BookingListViewModel
    {
        public int BookingId { get; set; }

        public string CustomerName { get; set; }

        public string BranchName { get; set; }

        [Display(Name = "Check-In Date")]
        public DateTime CheckInDate { get; set; }

        [Display(Name = "Check-Out Date")]
        public DateTime CheckOutDate { get; set; }

    }
}
