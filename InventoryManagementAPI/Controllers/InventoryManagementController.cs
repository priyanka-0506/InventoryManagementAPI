using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagementAPI.Boundary;
using InventoryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryManagementController : Controller
    {
        private readonly IInventoryManagementService _inventoryManagementService;

        public InventoryManagementController(IInventoryManagementService inventoryManagementService)
        {
            _inventoryManagementService = inventoryManagementService;
        }

        // GET: InventoryManagementController

        /// <summary>
        /// Gets all Items of inventory from the repository.
        /// </summary>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        [HttpGet]
        public async Task<IEnumerable<InventoryItemsDetails>> GetItemsAsync()
        {
            return await _inventoryManagementService.GetAllItemsAsync();
        }

        // GET: InventoryManagementController/Details/5
        /// <summary>
        /// Gets Items by Id from inventory.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        [HttpGet("itemId")]
        public async Task<InventoryItemsDetails> GetItemsByIdAsync(long itemId)
        {
            return await _inventoryManagementService.GetItemByIdAsync(itemId);
        }

        /// <summary>
        /// Add new Item in the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="inventoryItemsDetails">Inventory Items Details</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        // POST: InventoryManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<long> CreateItem(long itemId, InventoryItemsDetails inventoryItemsDetails)
        {
            return await _inventoryManagementService.AddNewItem(itemId, inventoryItemsDetails);
        }

        /// <summary>
        /// Update Item in the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <param name="inventoryItemsDetails">Inventory Items Details</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        [HttpPut]
        public async Task<string> UpdateItem(long itemId, InventoryItemsDetails inventoryItemsDetails)
        {
            return await _inventoryManagementService.UpdateItem(itemId, inventoryItemsDetails);
        }

        /// <summary>
        /// Delete Item from the list.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="DataConflictException"></exception>
        [HttpDelete]
        public async Task<string> DeleteItem(long itemId)
        {
            return await _inventoryManagementService.DeleteItem(itemId);
        }
    }
}
