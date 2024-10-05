using Domain;
using Domain.Interfaces;

namespace DataAccessEF.TypeRepository
{
    /// <summary>
    /// Order Repository inhererits the Generic Repository class and the Order Repository Interface
    /// </summary>
    class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EshopContext context) : base(context) { }

    }


}