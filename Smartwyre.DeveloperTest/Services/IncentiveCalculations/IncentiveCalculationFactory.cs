using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class IncentiveCalculationFactory
{
    public static IIncentiveCalculation Create(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                return new FixedCashAmountCalculation(rebate);
            case IncentiveType.FixedRateRebate:
                return new FixedRateRebateCalculation(rebate, product, request);
            case IncentiveType.AmountPerUom:
                return new AmountPerUomCalculation(rebate, request);
            default:
                return null;
        }
    }
}
