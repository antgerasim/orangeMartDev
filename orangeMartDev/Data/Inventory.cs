using System.Collections.Generic;

namespace orangeMartDev.Data
{
    public class Inventory : Entity
    {
        public ICollection<Product> Products { get; set; } //one inventory(Lager) has many products
        public int Quantity { get; set; }
        public int CurrentAmount { get; set; }
    }
}
