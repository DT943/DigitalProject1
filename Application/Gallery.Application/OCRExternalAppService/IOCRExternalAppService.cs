using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Application.OCRExternalAppService
{
    public interface IOCRExternalAppService
    {
        Task<string> ExtractTextFromUrlAsync(string imageUrl);
    }
}
