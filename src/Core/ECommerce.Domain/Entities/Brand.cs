namespace ECommerce.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Founder { get; set; }
        public string Contact { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
