using MyElectronix.Areas.Admin.Models;

namespace MyElectronix.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Category Category { get; set; }
        public virtual Order Order { get; set; }

    }
}