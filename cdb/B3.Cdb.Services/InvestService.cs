using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using System.Runtime.CompilerServices;

namespace B3.Cdb.Services;

public class InvestService : IInvestService
{
    private readonly ICdb cdb;

    public InvestService(ICdb cdb)
    {
        this.cdb = cdb;
    }

    public async Task<Position> CalculateCdbPositionAsync(Operation operation)
    {
        return await cdb.CalculateCdbPositionAsync(operation);
    }
}
