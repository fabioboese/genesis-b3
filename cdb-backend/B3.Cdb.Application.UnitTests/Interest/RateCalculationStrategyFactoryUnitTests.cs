using B3.Cdb.Application.Interest;
using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Infrastructure.Data;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.UnitTests.Interest;
public class RateCalculationStrategyFactoryUnitTests
{
    private readonly IRateCalculationStrategyFactory rateCalculationStrategyFactory;
    public RateCalculationStrategyFactoryUnitTests()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IIndicatorsRepository, IndicatorsRepository>();
        services.AddSingleton<IRateCalculationStrategyFactory, RateCalculationStrategyFactory>();

        ServiceProvider provider = services.BuildServiceProvider();
        rateCalculationStrategyFactory = provider.GetRequiredService<IRateCalculationStrategyFactory>();
    }

    [Fact]
    public void Create_WhenFixedRate_ReturnsFixedRateStrategy()
    {
        var rule = ProfitabilityRuleEnum.FixedRate;
        var result = rateCalculationStrategyFactory.Create(rule);
        result.Should().BeOfType<FixedRateStrategy>();
    }

    [Fact]
    public void Create_WhenFloatRate_ReturnsFixedRateStrategy()
    {
        var rule = ProfitabilityRuleEnum.FloatRate;
        var result = rateCalculationStrategyFactory.Create(rule);
        result.Should().BeOfType<FloatRateStrategy>();
    }

    [Fact]
    public void Create_WhenRateStrategyIsUnknown_ThrowNotImplementedException()
    {
        var action = () => rateCalculationStrategyFactory.Create((ProfitabilityRuleEnum)0);
        action.Should().Throw<NotImplementedException>();
    }
}
