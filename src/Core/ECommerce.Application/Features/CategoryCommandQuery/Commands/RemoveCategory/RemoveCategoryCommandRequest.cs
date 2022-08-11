using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Commands.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }

        public RemoveCategoryCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
