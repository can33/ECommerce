﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public Result(bool succeeded , IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }
        public static Result Success()
        {
            return new Result(true , Array.Empty<string>());
        }
        public static Result Failed(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }

    }
}
