using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.WrappingAppService.Dtos
{
    public class ResultDto
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public string Errors { get; set; }
    }
}
