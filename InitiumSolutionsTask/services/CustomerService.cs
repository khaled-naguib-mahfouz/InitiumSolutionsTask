namespace InitiumSolutionsTask.services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<(int CustomerId, bool IsExisting)> FindOrCreateCustomerAsync(string nationalId, string customerName, string phoneNumber)
        {
            // Check if the customer exists
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.NationalId == nationalId);

            if (customer == null)
            {
                // Create new customer if not found
                customer = new Customer
                {
                    NationalId = nationalId,
                    Name = customerName,
                    PhoneNumber = phoneNumber
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return (customer.CustomerId, false); // Not existing, newly created
            }

            return (customer.CustomerId, true); // Existing customer
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public bool CustomerExists(int customerId)
        {
            return _context.Customers.Any(c => c.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
