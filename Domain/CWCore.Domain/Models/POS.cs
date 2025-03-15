using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CWCore.Domain.Models
{
    public class POS : BasicEntityWithAuditInfo
    {
        public string Key { get; set; }

        public string? ArabicName { get; set; }

        public string? EnglishName { get; set; }
    }
}
