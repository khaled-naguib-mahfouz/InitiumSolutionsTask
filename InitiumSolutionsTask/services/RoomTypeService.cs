using Microsoft.EntityFrameworkCore;

namespace InitiumSolutionsTask.services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _context.RoomTypes
                           .Select(rt => new RoomType
                           {
                               RoomTypeId = rt.RoomTypeId,
                               TypeName = rt.TypeName,
                               Description = rt.Description
                           }).ToList();
        }

       
    }
}
