namespace InitiumSolutionsTask.services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<(int CustomerId, bool IsExisting)> FindOrCreateCustomerAsync(string nationalId, string customerName, string phoneNumber);
        void CreateCustomer(Customer customer);
        bool CustomerExists(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
