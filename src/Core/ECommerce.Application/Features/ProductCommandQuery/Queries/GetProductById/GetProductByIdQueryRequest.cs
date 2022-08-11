using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductCommandQuery.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<CustomResponseDto<ProductDto>>
    {
        public Guid Id { get; set; }
    }
}
