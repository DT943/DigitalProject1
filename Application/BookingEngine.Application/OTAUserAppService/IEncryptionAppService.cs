using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.OTAUserAppService
{
    public interface IEncryptionAppService
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);

    }
}
