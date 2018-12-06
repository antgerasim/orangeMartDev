using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace orangeMartDev.Data
{
    public class Product : Entity //AggregateRoot like ?
    {
        public string Sku { get; set; } //stock keeping unit
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DiscountModifier { get; set; } // 
        public ListingStatus ListingStatus { get; set; }
        //CategoryId - many Products to one Category
        public Category Category { get; set; }
        public Inventory Inventory { get; set; }
        public Receipt Receipt { get; set; }
        //public int MyProperty { get; set; }
        //Nav prop
        public ICollection<Review> Reviews { get; set; }
    }
}
