using B3.Cdb.Application.Interest;
using B3.Cdb.Application.Tax;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using B3.Cdb.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Services.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInvestServices(this IServiceCollection services)
    {
        // Domain services
        services.AddSingleton<ICdb, Domain.Model.Cdb>();

        // Infrastructure services
        services.AddSingleton<IAssetsRepository, AssetsRepository>();
        services.AddSingleton<IIndicatorsRepository, IndicatorsRepository>();
        services.AddSingleton<ITaxRateRepository, TaxRateRepository>();

        // Application services
        services.AddSingleton<RateCalculationStrategyFactory>();
        services.AddSingleton<ICompoundInterest, CompoundInterest>();
        services.AddSingleton<ITaxation, Taxation>();
        services.AddSingleton<IRateCalculationStrategyFactory, RateCalculationStrategyFactory>();

        // Service Facade
        services.AddSingleton<IInvestService, InvestService>();

        return services;
    }
}
