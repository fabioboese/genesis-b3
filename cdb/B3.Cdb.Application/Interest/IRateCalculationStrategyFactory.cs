using B3.Cdb.Domain.Enum;

namespace B3.Cdb.Application.Interest;

public interface IRateCalculationStrategyFactory
{
    IRateCalculationStrategy Create(ProfitabilityRuleEnum rule);
}