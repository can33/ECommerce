using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Dtos.CategoryDtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<CustomResponseDto<GetCategoryByIdDto>>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQueryRequest(Guid id)
        {
            Id = id;
        }

        
    }
}
