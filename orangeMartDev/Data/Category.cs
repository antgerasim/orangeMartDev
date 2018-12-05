using System.Collections.Generic;

namespace orangeMartDev.Data
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public ICollection<Product> Products { get; set; } // parentId
    }
}
