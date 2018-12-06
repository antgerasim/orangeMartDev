using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace orangeMartDev.Data
{
    [Table("Inventory")] //emphesize thats theres only one inventory
    public class Inventory : Entity
    {
        public ICollection<Product> Products { get; set; } //one inventory(Lager) has many products
        public int Quantity { get; set; }
        public int CurrentAmount { get; set; }
    }
}
