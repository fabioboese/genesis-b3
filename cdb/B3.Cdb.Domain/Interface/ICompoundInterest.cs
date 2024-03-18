using B3.Cdb.Domain.Model;

namespace B3.Cdb.Domain.Interface;
public interface ICompoundInterest
{
    Task<decimal> CalculateAsync(decimal principal, int months, ProfitabilityRule rule);
}