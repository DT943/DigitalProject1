using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CWCore.Application.POSAppService.Dtos
{
    public class POSCreateDto : IValidatableDto
    {
        public string Key { get; set; }

        public string? ArabicName { get; set; }

        public string? EnglishName { get; set; }
    }

    public class POSUpdateDto : IEntityUpdateDto
    {
        public string Key { get; set; }

        public string? ArabicName { get; set; }

        public string? EnglishName { get; set; }
    }

}
