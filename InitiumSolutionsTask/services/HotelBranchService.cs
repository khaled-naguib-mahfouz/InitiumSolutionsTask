namespace InitiumSolutionsTask.services
{
    public class HotelBranchService:IHotelBranchService
    {
        private readonly ApplicationDbContext _context;

        public HotelBranchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelBranch>> GetAllBranchesAsync()
        {
            return await _context.HotelBranches
                                 .ToListAsync();
        }
    
}
}
