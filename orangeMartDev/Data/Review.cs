using System.ComponentModel.DataAnnotations.Schema;

namespace orangeMartDev.Data
{
    [Table("Reviews")]
    public class Review : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //Nav Property
        public Product Product { get; set; }
    }
}
