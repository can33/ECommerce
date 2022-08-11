using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategoryWithProducts
{
    public class GetAllCategoryWithProductsQueryHandler : IRequestHandler<GetAllCategoryWithProductsQueryRequest, CustomResponseDto<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryWithProductsQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CategoryDto>>> Handle(GetAllCategoryWithProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllCategoryWithProducts();

            var dto = _mapper.Map<List<CategoryDto>>(categories);

            return CustomResponseDto<List<CategoryDto>>.Success(200,dto);
        }
    }
}
