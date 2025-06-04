using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberTransactionRedemptionDetails
    {
        public int Id { get; set; }

        public DateTime RedemptionDate { get; set; } = DateTime.Now;

        public int RedemptionValue { get; set; }

        [ForeignKey(nameof(TransactionId))]
        public MemberAccrualTransactions Transaction { get; set; }

        [ForeignKey(nameof(RedemptionId))]
        public MemberRedemptionTransactions Redemption { get; set; }

        public int TransactionId { get; set; }

        public int RedemptionId { get; set; }


    }
}
