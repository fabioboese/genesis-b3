using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Interest;

// As strategies foram criadas para representar como podemos escolher o algoritmo que vai ser executado em função de uma regra de negócio
internal class FixedRateStrategy : AbstractRateCalculationStrategy
{
    public override async Task<decimal> GetRateAsync(ProfitabilityRule rule) => await Task.FromResult(rule.Value);
}
