using Domain;
using Domain.Interfaces;

namespace DataAccessEF.TypeRepository
{
    /// <summary>
    /// Item repository inhererits the Generic Repository class and the Item Repository Interface
    /// </summary>
    class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(EshopContext context) : base(context) { }
    }
}