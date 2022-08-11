using ECommerce.Application.Dtos.BrandDtos;
using MediatR;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.BrandCommandQuery.Queries.GetAllBrand
{
    public class GetAllBrandQueryRequest : IRequest<CustomResponseDto<List<BrandListDto>>>
    {
    }
}
