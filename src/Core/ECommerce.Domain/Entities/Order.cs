namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public List<Product> Products { get; set; }
    }
}
