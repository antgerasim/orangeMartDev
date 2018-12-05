using System.Collections.Generic;

namespace orangeMartDev.Data
{
    public class Receipt : Entity //orderItem
    {
        //public Guid Id { get; set; }
        public string OrderName { get; set; }
        public IList<User> Users { get; set; } // one receipt has one Cashier, one Client and one Manager
        //public User Cashier { get; set; }
        //public User Manager { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public ICollection<Product> Products { get; set; } // one Receipt can have many Products
    }
}
