using AutoMapper;
using MediatR;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, CustomResponseDto<GetCategoryByIdDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetCategoryByIdDto>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByFilterAsync(x => x.Id == request.Id);

            if (category is null)   
                throw new NotFoundException($"Category is not found");

            var dto = _mapper.Map<GetCategoryByIdDto>(category);

            return CustomResponseDto<GetCategoryByIdDto>.Success(200, dto);

        }
    }
}
