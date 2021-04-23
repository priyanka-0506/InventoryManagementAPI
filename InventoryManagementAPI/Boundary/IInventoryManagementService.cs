using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.Boundary
{
    public interface IInventoryManagementService
    {
        /// <summary>
        /// Gets all Items of inventory from the repository.
        /// </summary>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        Task<IEnumerable<InventoryItemsDetails>> GetAllItemsAsync();

        /// <summary>
        /// Gets Items by Id from inventory.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        Task<InventoryItemsDetails> GetItemByIdAsync(long itemId);

        /// <summary>
        /// Add new Item in the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="inventoryItemsDetails">Inventory Items Details</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        Task<long> AddNewItem(long itemId, InventoryItemsDetails inventoryItemsDetails) ;

        /// <summary>
        /// Update Item in the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="inventoryItemsDetails">Inventory Items Details</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        Task<string> UpdateItem(long itemId, InventoryItemsDetails inventoryItemsDetails);

        /// <summary>
        /// Delete Item from the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        Task<string> DeleteItem(long itemId);
    }
}
