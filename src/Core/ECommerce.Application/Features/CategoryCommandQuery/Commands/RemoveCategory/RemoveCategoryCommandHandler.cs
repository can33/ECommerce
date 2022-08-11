using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repository;
using ECommerce.Application.Wrapper;
using MediatR;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest,CustomResponseDto<NoContentDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public RemoveCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<NoContentDto>> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var removeCategory = await _repository.GetByIdAsync(request.Id);
            if (removeCategory == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404,"Kayıt Bulunamadı.");
            }
            await _repository.RemoveAsync(removeCategory);
            return CustomResponseDto<NoContentDto>.Success(204);            
        }
    }
}
