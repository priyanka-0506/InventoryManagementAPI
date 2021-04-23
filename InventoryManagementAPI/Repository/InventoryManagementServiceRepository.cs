using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementAPI.Boundary;
using InventoryManagementAPI.Boundary.Exceptions;
using InventoryManagementAPI.DBContext;
using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Repository
{
    public class InventoryManagementServiceRepository : IInventoryManagementService
    {
        private readonly InventoryItemsDetailsContext _dbContext;

        public InventoryManagementServiceRepository(InventoryItemsDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<InventoryItemsDetails>> GetAllItemsAsync()
        {
            var test = _dbContext.InventoryItemsDetails.ToList();
            return await Task.FromResult(test);
        }

        public async Task<InventoryItemsDetails> GetItemByIdAsync(long itemId)
        {
            InventoryItemsDetails itemDetails = _dbContext.InventoryItemsDetails.Find(itemId);
            if (itemDetails == null)
            {
                return null;
            }

            return await Task.FromResult(itemDetails);
        }

        public Task<long> AddNewItem(long itemId, InventoryItemsDetails inventoryItemsDetails)
        {
            _dbContext.InventoryItemsDetails.Add(inventoryItemsDetails);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventoryItemsDetails.ItemId }, inventoryItemsDetails);
        }

        private Task<long> CreatedAtRoute(string v, object p, object student)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateItem(long itemId, InventoryItemsDetails inventoryItemsDetails)
        {
            if (itemId != inventoryItemsDetails.ItemId)
            {
                return null;
            }

            _dbContext.Entry(inventoryItemsDetails).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists((int)itemId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult("OK");
        }
        private bool ItemExists(int id)
        {
            return _dbContext.InventoryItemsDetails.Count(e => e.ItemId == id) > 0;
        }

        public async Task<string> DeleteItem(long itemId)
        {
            InventoryItemsDetails inventoryItemsDetails = _dbContext.InventoryItemsDetails.Find(itemId);
            if (inventoryItemsDetails == null)
            {
                return null;
            }

            _dbContext.InventoryItemsDetails.Remove(inventoryItemsDetails);
            _dbContext.SaveChanges();

            return await Task.FromResult("OK");
        }
    }
}
