namespace Domain.Interfaces
{

    /// <summary>
    /// The ICustomerRepository interface defines the methods that a CustomerRepository class should implement,
    /// it inherits from the IGenericRepository interface.
    /// </summary>
    public interface ICustomerRepository : IGenericRepository<Customer> { }
}
