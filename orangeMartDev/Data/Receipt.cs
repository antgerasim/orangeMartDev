namespace orangeMartDev.Data
{
    public class Receipt : Entity //orderItem
    {
        //public Guid Id { get; set; }
        public string OrderName { get; set; }
        public User Cashier { get; set; }
        public User Manager { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }

    }
}
