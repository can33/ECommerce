using AutoMapper;
using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repositories;
using ECommerce.Application.Wrapper;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest,CustomResponseDto<NoContentDto>>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedBrand = _mapper.Map<Brand>(request);

            await _repository.UpdateAsync(updatedBrand);

            return CustomResponseDto<NoContentDto>.Success(204);
        }
    }
}
