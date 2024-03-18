using B3.Cdb.Application.Interest;
using B3.Cdb.Domain.Enum;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace B3.Cdb.Application.UnitTests.Interest;

public class CompoundInterestUnitTest
{
    private readonly ICompoundInterest compoundInterest;
    private readonly Mock<IIndicatorsRepository> indicatorsRepositoryMock = new();
    private readonly Mock<IRateCalculationStrategyFactory> rateCalculationStrategyFactoryMock = new();
    private readonly Mock<IRateCalculationStrategy> floatRateStrategyMock = new();

    public CompoundInterestUnitTest()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<ICompoundInterest, CompoundInterest>();
        services.AddSingleton(indicatorsRepositoryMock.Object);
        services.AddSingleton(rateCalculationStrategyFactoryMock.Object);

        ServiceProvider provider = services.BuildServiceProvider();
        compoundInterest = provider.GetRequiredService<ICompoundInterest>();
    }

    [Theory]
    [InlineData(1000, 12, 1.10, 125.49)] // 110% do CDI
    [InlineData(1000, 12, 1.08, 123.08)] // 108% do CDI
    [InlineData(1000, 12, 0.90, 101.65)] //  90% do CDI
    public async Task CalculateAsync_FloatRate_Successfully(decimal initialValue, int months, decimal rate, decimal expectedValue)
    {
        //floatRateStrategyMock.Setup(x => x.GetRateAsync(It.IsAny<ProfitabilityRule>())).ReturnsAsync(rate);
        indicatorsRepositoryMock.Setup(x => x.GetIndicatorValueAsync(It.IsAny<string>())).ReturnsAsync(0.009M);
        ProfitabilityRule rule = new ProfitabilityRule { Value = rate };
        rateCalculationStrategyFactoryMock.Setup(x => x.Create(It.IsAny<ProfitabilityRuleEnum>())).Returns(new FloatRateStrategy(indicatorsRepositoryMock.Object));
        var result = Math.Round(await compoundInterest.CalculateAsync(initialValue, months, rule), 2);
        result.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData(1000, 12, 0.10, 2138.43)]
    [InlineData(1000, 12, 0.01, 126.83)]
    [InlineData(1000, 12, 0.005, 61.68)]
    public async Task CalculateAsync_FixedRate_Successfully(decimal initialValue, int months, decimal rate, decimal expectedValue)
    {
        ProfitabilityRule rule = new ProfitabilityRule { Value = rate };
        rateCalculationStrategyFactoryMock.Setup(x => x.Create(It.IsAny<ProfitabilityRuleEnum>())).Returns(new FixedRateStrategy ());
        var result = Math.Round(await compoundInterest.CalculateAsync(initialValue, months, rule), 2);
        result.Should().Be(expectedValue);
    }


}