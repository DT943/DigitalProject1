using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Application.Exceptions
{

    public class CustomValidationException : Exception
    {
        public ValidationProblemDetails ProblemDetails { get; }

        public CustomValidationException(ValidationProblemDetails details)
            : base(details.Title)
        {
            ProblemDetails = details;
        }
    }

}
