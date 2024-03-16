using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Interest;

// As strategies foram criadas para representar como podemos escolher o algoritmo que vai ser executado em função de uma regra de negócio
internal class FloatRateStrategy : AbstractRateCalculationStrategy
{
    private readonly IIndicatorsRepository indicatorsRepository;

    public FloatRateStrategy(IIndicatorsRepository indicatorsRepository)
    {
        this.indicatorsRepository = indicatorsRepository;
    }
    public override async Task<decimal> GetRateAsync(ProfitabilityRule rule) => rule.Value * await indicatorsRepository.GetIndicatorValueAsync(rule.Benchmark);
}
