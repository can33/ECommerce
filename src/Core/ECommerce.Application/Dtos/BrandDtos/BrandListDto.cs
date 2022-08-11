namespace ECommerce.Application.Dtos.BrandDtos
{
    public class BrandListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Founder { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
