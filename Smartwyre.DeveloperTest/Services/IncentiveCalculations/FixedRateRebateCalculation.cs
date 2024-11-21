using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class FixedRateRebateCalculation(Rebate rebate, Product product, CalculateRebateRequest request) : IIncentiveCalculation
{
    public bool Validate()
    {
        return rebate.Percentage != 0 && product.Price != 0 && request.Volume != 0;
    }

    public decimal CalculateRebate()
    {
        return product.Price * rebate.Percentage * request.Volume;
    }
}
