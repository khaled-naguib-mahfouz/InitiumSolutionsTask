namespace InitiumSolutionsTask.services
{
    public interface IHotelBranchService
    {
        Task<IEnumerable<HotelBranch>> GetAllBranchesAsync();

    }
}
