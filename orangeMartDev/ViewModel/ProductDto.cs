using orangeMartDev.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orangeMartDev.ViewModel
{
    public class ProductDto
    {
        // public string Sku { get; set; } //stock keeping unit
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public IList<Review> Reviews { get; set; }


    }
}
