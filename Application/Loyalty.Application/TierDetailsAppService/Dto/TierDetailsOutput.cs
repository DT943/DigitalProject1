using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.TierDetailsAppService.Dto
{
    public class TierDetailsGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int TireLifeSpanYears { get; set; }

        public int BonusLifeSpanYears { get; set; } //-1 for unlimited value 

        public float BonusAddedValue { get; set; } // for example we will add 25% for each added transaction

        public int RequiredMilesToReach { get; set; } // for example (75,000) miles for Diamond
    }
}
