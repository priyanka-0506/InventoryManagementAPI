using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.DBContext
{
    public class InventoryItemsDetailsContext : DbContext
    {
        public InventoryItemsDetailsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<InventoryItemsDetails> InventoryItemsDetails { get; set; }
    }
}
