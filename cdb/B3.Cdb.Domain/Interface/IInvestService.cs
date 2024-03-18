
using B3.Cdb.Domain.Model;

namespace B3.Cdb.Domain.Interface;

public interface IInvestService
{
    Task<Position> CalculateCdbPositionAsync(Operation operation);
}