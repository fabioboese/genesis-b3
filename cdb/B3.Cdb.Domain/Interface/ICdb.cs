
namespace B3.Cdb.Domain.Model;

public interface ICdb
{
    Task<Position> CalculateCdbPositionAsync(Operation operation);
}