using B3.Cdb.Domain.Model;

namespace B3.Cdb.Domain.Interface;
public interface IAssetsRepository
{
    Task<ProfitabilityRule> GetProfitabilityRuleAsync(string asset);
}