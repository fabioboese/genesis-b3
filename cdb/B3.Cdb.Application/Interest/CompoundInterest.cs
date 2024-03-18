using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;

namespace B3.Cdb.Application.Interest;

public class CompoundInterest : ICompoundInterest
{
    private readonly IRateCalculationStrategyFactory factory;

    public CompoundInterest(IRateCalculationStrategyFactory factory)
    {
        this.factory = factory;
    }

    public async Task<decimal> CalculateAsync(decimal initialValue, int months, ProfitabilityRule rule)
    {
        var rate = (double) await factory.Create(rule.Rule).GetRateAsync(rule);
        var result = initialValue * (decimal)(Math.Pow(1 + rate, months) - 1);
        return result;
    }
}
