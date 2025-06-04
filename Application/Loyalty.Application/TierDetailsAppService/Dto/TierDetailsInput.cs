using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.TierDetailsAppService.Dto
{
    public class TierDetailsCreateDto : IValidatableDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int TireLifeSpanYears { get; set; }

        public int BonusLifeSpanYears { get; set; } //-1 for unlimited value 

        public float BonusAddedValue { get; set; } // for example we will add 25% for each added transaction

        public int RequiredMilesToReach { get; set; } // for example (75,000) miles for Diamond
    }

    public class TierDetailsUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int TireLifeSpanYears { get; set; }

        public int BonusLifeSpanYears { get; set; } //-1 for unlimited value 

        public float BonusAddedValue { get; set; } // for example we will add 25% for each added transaction

        public int RequiredMilesToReach { get; set; } // for example (75,000) miles for Diamond
    }
}
