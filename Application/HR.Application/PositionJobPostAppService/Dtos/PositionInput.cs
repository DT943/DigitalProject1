using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace HR.Application.PositionAppService.Dtos
{
    public class PositionCreateDto : IValidatableDto
    {
        public string Name { get; set; }
    }

    public class PositionUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }

    }
}




