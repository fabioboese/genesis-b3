
namespace B3.Cdb.Domain.Interface;

public interface ITaxation
{
    Task<decimal> CalculateTaxAsync(string taxName, decimal baseValue, int months);
}