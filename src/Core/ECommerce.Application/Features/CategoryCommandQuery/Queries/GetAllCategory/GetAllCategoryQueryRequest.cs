using MediatR;
using ECommerce.Application.Dtos;
using ECommerce.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.CategoryCommandQuery.Queries.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<CustomResponseDto<List<CategoryListDto>>>
    {
    }
}
