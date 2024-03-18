using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Interest;
public class RateCalculationStrategyFactory : IRateCalculationStrategyFactory
{
    private readonly IIndicatorsRepository indicatorsRepository;

    public RateCalculationStrategyFactory(IIndicatorsRepository indicatorsRepository)
    {
        this.indicatorsRepository = indicatorsRepository;
    }

    public IRateCalculationStrategy Create(ProfitabilityRuleEnum rule)
    {
        return rule switch
        {
            ProfitabilityRuleEnum.FixedRate => new FixedRateStrategy(),
            ProfitabilityRuleEnum.FloatRate => new FloatRateStrategy(indicatorsRepository),
            _ => throw new NotImplementedException()
        };
    }
}
