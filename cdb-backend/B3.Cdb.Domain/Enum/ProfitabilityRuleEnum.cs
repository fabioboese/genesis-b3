using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Domain.Enum;
public enum ProfitabilityRuleEnum
{
    FixedRate = 1,  // o percentual indicado é fixo, tratando-se, portanto, de uma taxa prefixada
    FloatRate = 2   // o percentual indicado é o percentual de variação em relação a um indexador, tratando-se, portanto, de uma taxa pós-fixada
}
