
namespace B3.Cdb.Domain.Interface;

public interface ITaxRateRepository
{
    Task<decimal> GetTaxRateAsync(string taxName, int months);
}