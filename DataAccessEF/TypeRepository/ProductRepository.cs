using Domain;
using Domain.Interfaces;

namespace DataAccessEF.TypeRepository
{
    /// <summary>
    /// Product Repository inhererits the Generic Repository class and the Product Repository Interface
    /// </summary>
    class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EshopContext context) : base(context) { }
    }
}