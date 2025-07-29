using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlight.Application.WrappingAppService
{
    public interface IWrappingAirPriceAppService
    {
        string CreateAirPriceRequestXml(string transactionId, List<Dictionary<string, object>> segments,
            int adult, int child, int infant, string cabin, string flightType);
        Task<string> CallAirPriceApiAsync(string xmlRequest);
        Dictionary<string, object> ParseTransactionResponse(string xmlData);
        List<Dictionary<string, object>> ParseResponse(string xmlData);

    }
}
