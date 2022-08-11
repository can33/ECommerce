using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.BrandCommandQuery.Commands.AddBrand
{
    public class AddBrandCommandRequest : IRequest<CustomResponseDto<AddBrandDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Founder { get; set; }
        public string Contact { get; set; }
    }
}
