using B3.Cdb.Domain.Model;

namespace B3.Cdb.Application.Interest;

public interface IRateCalculationStrategy
{
    Task<decimal> GetRateAsync(ProfitabilityRule rule);
}