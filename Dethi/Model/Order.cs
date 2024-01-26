using System.ComponentModel.DataAnnotations;

namespace Dethi.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int IdProduct {  get; set; }
        public string ProductName { get; set; }
        public int QuantityOrder { set; get; }
        public decimal TotalPrice { set; get; }
        public string Adress { set; get; }
        public string PhoneNuber { set; get; }
        public DateTime TimeShip { set; get; }

    }
}
