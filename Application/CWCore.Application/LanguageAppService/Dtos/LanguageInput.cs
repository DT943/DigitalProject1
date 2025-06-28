using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CWCore.Application.LanguageAppService.Dtos
{
    public class LanguageCreateDto: IValidatableDto
    {
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public bool IsActive { get; set; } = true;


    }
    public class LanguageUpdateDto: IEntityUpdateDto
    {
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
