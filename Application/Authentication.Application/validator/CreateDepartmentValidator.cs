using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Authentication.Application.Dtos;

namespace Authentication.Application.validator
{
    
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Department Name is required.");
        }
    }

}
