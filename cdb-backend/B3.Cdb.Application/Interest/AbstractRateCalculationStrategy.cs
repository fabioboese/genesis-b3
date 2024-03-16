using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Interest;
internal abstract class AbstractRateCalculationStrategy
{
    abstract public Task<decimal> GetRateAsync(ProfitabilityRule rule);
}
