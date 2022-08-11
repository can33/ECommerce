namespace ECommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Defination { get; set; }
        public List<Product> Products { get; set; }
    }
}
