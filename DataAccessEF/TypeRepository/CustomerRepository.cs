using Domain;
using Domain.Interfaces;

namespace DataAccessEF.TypeRepository
{
    /// <summary>
    /// Customer repository inhererits the Generic Repository class and the Customer Repository Interface
    /// </summary>
    class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EshopContext context) : base(context) { }
    }
}
