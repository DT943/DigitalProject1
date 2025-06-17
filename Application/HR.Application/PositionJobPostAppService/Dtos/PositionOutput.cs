using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.PositionAppService.Dtos
{
    public class PositionGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; } 

    }

    public class PositionGetAllDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
        public string Name { get; set; }
    }

}
