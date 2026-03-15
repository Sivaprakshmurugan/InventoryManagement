using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("inventoryitems")]
    public class InventoryItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("status")]
        public int Status { get; set; }
    }
}
