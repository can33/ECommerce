﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public Guid Id { get; set; }
        public string Defination { get; set; }
    }
}
