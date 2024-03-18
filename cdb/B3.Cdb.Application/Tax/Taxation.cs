using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.Tax;
public class Taxation : ITaxation
{
    private readonly ITaxRateRepository taxRateRepository;

    public Taxation(ITaxRateRepository taxRateRepository)
    {
        this.taxRateRepository = taxRateRepository;
    }

    public async Task<decimal> CalculateTaxAsync(string taxName, decimal baseValue, int months)
    {
        var rate = await taxRateRepository.GetTaxRateAsync(taxName, months);
        return rate * baseValue;
    }
}
