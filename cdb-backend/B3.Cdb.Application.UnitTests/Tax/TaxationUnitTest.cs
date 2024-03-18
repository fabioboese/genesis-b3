using B3.Cdb.Application.Interest;
using B3.Cdb.Application.Tax;
using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using B3.Cdb.Infrastructure.Data;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Cdb.Application.UnitTests.Tax;
public class TaxationUnitTest
{
    private readonly ITaxation taxation;
    private readonly Mock<IIndicatorsRepository> indicatorsRepositoryMock = new();
    private readonly Mock<IRateCalculationStrategyFactory> rateCalculationStrategyFactoryMock = new();
    private readonly Mock<IRateCalculationStrategy> floatRateStrategyMock = new();

    public TaxationUnitTest()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<ITaxation, Taxation>();
        services.AddSingleton<ITaxRateRepository, TaxRateRepository>();

        ServiceProvider provider = services.BuildServiceProvider();
        taxation = provider.GetRequiredService<ITaxation>();
    }

    [Theory]
    [InlineData(1000, 5, 225.00)]
    [InlineData(1000, 6, 225.00)]
    [InlineData(1000, 7, 200.00)]
    [InlineData(1000, 11, 200.00)]
    [InlineData(1000, 12, 200.00)]
    [InlineData(1000, 13, 175.00)]
    [InlineData(1000, 23, 175.00)]
    [InlineData(1000, 24, 175.00)]
    [InlineData(1000, 25, 150.00)]
    [InlineData(1000, 36, 150.00)]
    public async Task CalculateTaxAsync_Successfully(decimal baseValue, int months, decimal expectedValue)
    {
        var tax = await taxation.CalculateTaxAsync("any-name", baseValue, months);
        tax.Should().Be(expectedValue);
    }
}
