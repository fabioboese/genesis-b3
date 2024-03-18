using B3.Cdb.Domain.Interface;

namespace B3.Cdb.Infrastructure.Data;

// Esta classe foi criada para simular o acesso a uma base de dados contendo os valores dos indicadores
public class IndicatorsRepository : IIndicatorsRepository
{
    public async Task<decimal> GetIndicatorValueAsync(string? indicator)
    {
        // aqui o indicador correspondente seria buscado em uma base de dados (no caso está retornando 0.9% para qualquer indicador diferente de nulo)
        if (indicator == null)
            return await Task.FromResult(0M);

        return await Task.FromResult(0.009M);
    }
}
