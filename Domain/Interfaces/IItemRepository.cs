﻿namespace Domain.Interfaces
{

    /// <summary>
    /// The IItemRepository interface defines the methods that a ItemRepository class should implement,
    /// it inherits from the IGenericRepository interface.
    /// </summary>
    public interface IItemRepository : IGenericRepository<Item> { }
}
