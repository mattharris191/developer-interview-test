using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class IncentiveCalculationsTests
{
    [Fact]
    public void IncentiveCalculations_ShouldReturnFalse_FixedCashAmountFailedValidation()
    {
        var rebate = new Rebate() { Incentive = IncentiveType.FixedCashAmount, Amount = 0 };
        var incentiveCalculation = IncentiveCalculationFactory.Create(rebate, new Product(), new CalculateRebateRequest());
        
        var result = incentiveCalculation.Validate();

        Assert.False(result);
    }

    [Fact]
    public void IncentiveCalculations_ShouldReturnFalse_FixedRateRebateFailedValidation()
    {
        var rebate = new Rebate() { Incentive = IncentiveType.FixedRateRebate, Percentage = 0 };
        var incentiveCalculation = IncentiveCalculationFactory.Create(rebate, new Product(), new CalculateRebateRequest());

        var result = incentiveCalculation.Validate();

        Assert.False(result);
    }

    [Fact]
    public void IncentiveCalculations_ShouldReturnFalse_AmountPerUomFailedValidation()
    {
        var rebate = new Rebate() { Incentive = IncentiveType.AmountPerUom, Amount = 0 };
        var incentiveCalculation = IncentiveCalculationFactory.Create(rebate, new Product(), new CalculateRebateRequest());

        var result = incentiveCalculation.Validate();

        Assert.False(result);
    }
}
