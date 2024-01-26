using System.ComponentModel.DataAnnotations;

namespace Dethi.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { set; get; }
        public string ProductDescription { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }

    }
}
