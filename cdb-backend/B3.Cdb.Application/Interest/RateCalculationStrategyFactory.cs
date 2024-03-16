using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Interest;
public class RateCalculationStrategyFactory
{
    private readonly IIndicatorsRepository indicatorsRepository;

    public RateCalculationStrategyFactory(IIndicatorsRepository indicatorsRepository)
    {
        this.indicatorsRepository = indicatorsRepository;
    }

    internal AbstractRateCalculationStrategy Create(ProfitabilityRuleEnum rule)
    {
        return rule switch
        {
            ProfitabilityRuleEnum.FixedRate => new FixedRateStrategy(),
            ProfitabilityRuleEnum.FloatRate => new FloatRateStrategy(indicatorsRepository),
            _ => throw new NotImplementedException()
        };
    }
}
