using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    [Fact]
    public void RebateService_ShouldReturnFalse_RebateNull()
    {
        RebateService rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            ProductIdentifier = "TestProduct1",
            Volume = 5m
        };

        var result = rebateService.Calculate(request);

        Assert.False(result.Success);
    }

    [Fact]
    public void RebateService_ShouldReturnFalse_ProductNull()
    {
        RebateService rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "TestRebate1",
            Volume = 5m
        };

        var result = rebateService.Calculate(request);

        Assert.False(result.Success);
    }

    [Fact]
    public void RebateService_ShouldReturnTrue_RebateIncentiveTypeSupportedByProduct()
    {
        RebateService rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "TestRebate1",
            ProductIdentifier = "TestProduct1",
            Volume = 5m
        };

        var result = rebateService.Calculate(request);

        Assert.True(result.Success);
    }

    [Fact]
    public void RebateService_ShouldReturnTrue_RebateIncentiveTypeOfMultipleSupportedByProduct()
    {
        RebateService rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "TestRebate2",
            ProductIdentifier = "TestProduct2",
            Volume = 5m
        };

        var result = rebateService.Calculate(request);

        Assert.True(result.Success);
    }

    [Fact]
    public void RebateService_ShouldReturnFalse_RebateIncentiveTypeUnsupportedByProduct()
    {
        RebateService rebateService = new RebateService();

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "TestRebate1",
            ProductIdentifier = "TestProduct2",
            Volume = 5m
        };

        var result = rebateService.Calculate(request);

        Assert.False(result.Success);
    }
}
