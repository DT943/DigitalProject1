using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberAccrualTransactions : BasicEntity
    {
        public int PartnerId { get; set; }

        public DateTime ActDate { get; set; }

        public float ActValue { get; set; }

        public int Base {  get; set; }

        public int Bonus { get; set; }

        public int ReversalId { get; set; }

        public int TierId { get; set; }

        public string Description { get; set; }

        public string LoadType { get; set; }

        public DateTime STMTDate { get; set; }

        public string ActInvNumber { get; set; }

        public DateTime INVDate { get; set; }

        public int STMTNo { get; set; }

        public int INVNo { get; set; }

        public DateTime LoadDate { get; set; }



    }
}
