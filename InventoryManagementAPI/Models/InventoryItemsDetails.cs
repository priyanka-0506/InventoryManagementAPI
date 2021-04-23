using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagementAPI.Models.Enums;

namespace InventoryManagementAPI.Models
{
    public class InventoryItemsDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long ItemMaterialNum { get; set; }
        public DateTime CreatedDate { get; set; }
        public ItemState State { get; set; } = ItemState.Manufacturing;
        public string Discription { get; set; }
    }
}
