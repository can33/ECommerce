using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
