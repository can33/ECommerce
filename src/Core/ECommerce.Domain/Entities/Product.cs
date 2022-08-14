using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("BrandId")]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
