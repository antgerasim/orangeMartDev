namespace orangeMartDev.Data
{
    public class Inventory : Entity
    {
        public Product Product { get; set; } //many-to-one?
        public int Quantity { get; set; }
        public int CurrentAmount { get; set; }
    }
}
