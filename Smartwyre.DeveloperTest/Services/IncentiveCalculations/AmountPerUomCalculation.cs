using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class AmountPerUomCalculation(Rebate rebate, CalculateRebateRequest request) : IIncentiveCalculation
{
    public bool Validate()
    {
        return rebate.Amount != 0 && request.Volume != 0;
    }

    public decimal CalculateRebate()
    {
        return rebate.Amount * request.Volume;
    }
}
