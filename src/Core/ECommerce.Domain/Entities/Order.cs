using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public List<Product> Products { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Address { get; set; }

    }
}
