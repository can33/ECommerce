using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.UpdateBrand
{
    public class UpdateBrandCommandRequest : IRequest<CustomResponseDto<NoContentDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Founder { get; set; }
        public string Contact { get; set; }
    }
}
