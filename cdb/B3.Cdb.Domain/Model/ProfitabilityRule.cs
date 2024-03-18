using B3.Cdb.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Domain.Model;
public class ProfitabilityRule
{
    public string? Name { get; set; }
    public decimal Value { get; set; }
    public string? Benchmark { get; set; }
    public ProfitabilityRuleEnum Rule { get; set; } = ProfitabilityRuleEnum.FixedRate;
    public string Tax { get; set; } = string.Empty;

}
