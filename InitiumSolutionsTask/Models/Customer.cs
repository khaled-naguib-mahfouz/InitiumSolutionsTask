namespace InitiumSolutionsTask.Models
{
    public class Customer
    {
       
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string NationalId { get; set; }
            public string PhoneNumber { get; set; }
            public bool HasBookedBefore { get; set; }

            // Navigation Property
            public ICollection<Booking> Bookings { get; set; }
        

    }
}
