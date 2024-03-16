using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Infrastructure.Data;

// Esta classe foi criada para simular o acesso a uma base de dados dos ativos
public class AssetsRepository : IAssetsRepository
{
    public async Task<ProfitabilityRule> GetProfitabilityRuleAsync(string asset)
    {
        // aqui o ativo correspondente seria buscado em uma base de dados (no caso está retornando somente a regra de pagamento de 108% sobre o CDI)
        return await Task.FromResult(new ProfitabilityRule { Name = "108%CDI", Value = 1.08M, Benchmark = "CDI", Rule = ProfitabilityRuleEnum.FloatRate });
    }
}
