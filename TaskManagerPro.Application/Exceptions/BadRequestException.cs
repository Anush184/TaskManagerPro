﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace TaskManagerPro.Application.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string message): base(message)
        {

        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = new();
            foreach(var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
        public List<string> ValidationErrors { get; set; }
    }
}
