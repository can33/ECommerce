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

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, CustomResponseDto<List<CategoryListDto>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CategoryListDto>>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();

            var dto = _mapper.Map<List<CategoryListDto>>(categories);
            
            return CustomResponseDto<List<CategoryListDto>>.Success(200,dto);

        }
    }
}
