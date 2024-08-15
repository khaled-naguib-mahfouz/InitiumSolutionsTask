namespace InitiumSolutionsTask.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public ICollection<Room> Rooms { get; set; }
    }
}
