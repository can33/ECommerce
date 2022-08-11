using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, CustomResponseDto<AddCategoryDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<AddCategoryDto>> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var addedCategory = _mapper.Map<Category>(request);

            await _repository.CreateAsync(addedCategory);

            var dto = _mapper.Map<AddCategoryDto>(addedCategory);

            return CustomResponseDto<AddCategoryDto>.Success(201, dto);
        }
    }
}
