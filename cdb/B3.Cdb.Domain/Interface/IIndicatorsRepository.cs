namespace B3.Cdb.Domain.Interface;

public interface IIndicatorsRepository
{
    Task<decimal> GetIndicatorValueAsync(string? indicator);
}