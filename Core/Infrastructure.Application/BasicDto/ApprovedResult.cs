using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.BasicDto
{
    public class ApprovedResult<T>
    {
        public  T Item { get; set; }
        public string Result { get; set; }
    }
}
