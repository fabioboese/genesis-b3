using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;

namespace B3.Cdb.Application.Interest;

public class CompoundInterest : ICompoundInterest
{
    private readonly RateCalculationStrategyFactory factory;

    public CompoundInterest(RateCalculationStrategyFactory factory)
    {
        this.factory = factory;
    }

    public async Task<decimal> CalculateAsync(decimal principal, int months, ProfitabilityRule rule)
    {
        var rate = (double) await factory.Create(rule.Rule).GetRateAsync(rule);
        var result = principal * (decimal)(Math.Pow(1 + rate, months) - 1);
        return result;
    }
}
