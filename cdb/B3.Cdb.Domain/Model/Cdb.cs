using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Domain.Model;
public class Cdb : ICdb
{
    private readonly IAssetsRepository assetsRepository;
    private readonly ICompoundInterest compoundInterest;
    private readonly ITaxation taxation;

    public Cdb(IAssetsRepository assetsRepository, ICompoundInterest compoundInterest, ITaxation taxation)
    {
        this.assetsRepository = assetsRepository;
        this.compoundInterest = compoundInterest;
        this.taxation = taxation;
    }

    public async Task<Position> CalculateCdbPositionAsync(Operation operation)
    {
        CdbCalculationValidator validator = new();
            validator.Validate(operation);

        var rule = await assetsRepository.GetProfitabilityRuleAsync(operation.AssetName);
        var grossProfit = Math.Round(await compoundInterest.CalculateAsync(operation.Principal, operation.Months, rule),2);
        var incomeTax = Math.Round(await taxation.CalculateTaxAsync(rule.Tax, grossProfit, operation.Months), 2);
        return new Position { GrossValue = operation.Principal + grossProfit, IncomeTax = incomeTax, NetValue = operation.Principal + grossProfit - incomeTax };
    }
}
