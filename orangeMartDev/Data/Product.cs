using System;
using System.Linq;
using System.Threading.Tasks;

namespace orangeMartDev.Data
{
    public class Product : Entity //AggregateRoot like ?
    {
       // public Guid Id { get; set; }    
        public string Sku { get; set; } //many-to-one with Category
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DiscountModifier { get; set; } // 
        public ListingStatus ListingStatus { get; set; }
        //CategoryId - many Products to one Category
        public Category Category { get; set; }
    }
}
