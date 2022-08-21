using AutoMapper;
using Bogus;
using ECommerce.Application.Features.ProductCommandQuery.Commands.AddProduct;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Mapping;
using ECommerce.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Test.Application
{
    public class AddProductCommandHandlerTests
    {
        private static IMapper _mapper;
        [Fact]
        public async void AddProduct_ValidProduct_ReturnCreated()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new ProductMapping());
            });

            _mapper = mapperConfig.CreateMapper();

            AddProductCommandRequest request = new AddProductCommandRequest()
            {
                Name = "Test 1",
                Stock = 3,
                Price = 50 ,
                CategoryId = new System.Guid("73b10b78-72b2-43cb-e189-08da7bdbbac7"),
                BrandId = new System.Guid("867999aa-8cad-4c93-090d-08da7bdb58d6"),

            };
            var mappedProduct = _mapper.Map<Product>(request);

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.CreateAsync(mappedProduct)).Returns(Task.CompletedTask);

            var commandRequest = new AddProductCommandHandler(mockRepository.Object, _mapper);
            var response = await commandRequest.Handle(request, System.Threading.CancellationToken.None);

            Assert.NotNull(response);


        }

    }
}
