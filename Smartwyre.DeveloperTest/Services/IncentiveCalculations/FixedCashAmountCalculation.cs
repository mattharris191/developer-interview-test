using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class FixedCashAmountCalculation(Rebate rebate) : IIncentiveCalculation
{
    public bool Validate()
    {
        return rebate.Amount != 0;
    }

    public decimal CalculateRebate()
    {
        return rebate.Amount;
    }
}
