using B3.Cdb.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Infrastructure.Data;

// Esta classe foi criada para simular o acesso a uma base de dados contendo as alíquotas de impostos aplicáveis
public class TaxRateRepository : ITaxRateRepository
{
    public async Task<decimal> GetTaxRateAsync(string taxName, int months)
    {
        // aqui é retornada a alíquota para o imposto e o tempo de investimento correspondentes (no caso está retornando a mesma regra de tributação para qualquer imposto)
        return await Task.FromResult(months switch
        {
            <= 6 => 0.225M,
            <= 12 => 0.20M,
            <= 24 => 0.175M,
            _ => 0.15M,
        });
    }
}
