using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, CustomResponseDto<NoContentDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var updatedCategory = _mapper.Map<Category>(request);

            await _repository.UpdateAsync(updatedCategory);

            return CustomResponseDto<NoContentDto>.Success(204);

        }
    }
}
