
namespace InitiumSolutionsTask.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelBranch> HotelBranches { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure RoomBooking -> Booking relationship
            modelBuilder.Entity<RoomBooking>()
                .HasOne(rb => rb.Booking)
                .WithMany(b => b.RoomBookings)
                .HasForeignKey(rb => rb.BookingId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict to avoid cascade delete

            // Configure RoomBooking -> Room relationship
            modelBuilder.Entity<RoomBooking>()
                .HasOne(rb => rb.Room)
                .WithMany(r => r.RoomBookings)
                .HasForeignKey(rb => rb.RoomId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict to avoid cascade delete

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "John Doe", PhoneNumber = "555-1234" ,NationalId="222222"},
                new Customer { CustomerId = 2, Name = "Jane Smith", PhoneNumber = "555-5678",NationalId= "333333" }
            );

            // Seed data for HotelBranches
            modelBuilder.Entity<HotelBranch>().HasData(
                new HotelBranch { BranchId = 1, BranchName = "Main Branch", Location = "Downtown" },
                new HotelBranch { BranchId = 2, BranchName = "Airport Branch", Location = "Airport" }
            );

            // Seed data for RoomTypes
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { RoomTypeId = 1, TypeName = "Single", Description = "A single room" },
                new RoomType { RoomTypeId = 2, TypeName = "Double", Description = "A double room" },
                new RoomType { RoomTypeId = 3, TypeName = "Suite", Description = "A luxury suite" }
            );

            // Seed data for Rooms
            modelBuilder.Entity<Room>().HasData(
             new Room
             {
                 RoomId = 1,
                 RoomTypeId = 1,
                 BranchId = 1,
                 RoomNumber = "101"
             },
             new Room
             {
                 RoomId = 2,
                 RoomTypeId = 2,
                 BranchId = 1,
                 RoomNumber = "102"
             },
             new Room
             {
                 RoomId = 3,
                 RoomTypeId = 3,
                 BranchId = 2,
                 RoomNumber = "201"
             }
         );

            // Seed data for Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId = 1, CustomerId = 1, BranchId = 1, CheckInDate = new DateTime(2024, 08, 15), CheckOutDate = new DateTime(2024, 08, 20), NumberOfRooms = 1, DiscountApplied = 0 },
                new Booking { BookingId = 2, CustomerId = 2, BranchId = 2, CheckInDate = new DateTime(2024, 08, 18), CheckOutDate = new DateTime(2024, 08, 22), NumberOfRooms = 2, DiscountApplied = 0 }
            );

            // Seed data for RoomBookings
            modelBuilder.Entity<RoomBooking>().HasData(
                new RoomBooking { RoomBookingId = 1, BookingId = 1, RoomId = 1, NumberOfAdults = 1, NumberOfChildren = 0 },
                new RoomBooking { RoomBookingId = 2, BookingId = 2, RoomId = 2, NumberOfAdults = 2, NumberOfChildren = 1 }
            );
        }



    }
}
