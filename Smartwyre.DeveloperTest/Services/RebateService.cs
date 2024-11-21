
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebateDataStore = new RebateDataStore();
        var productDataStore = new ProductDataStore();

        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        var rebateAmount = 0m;

        if (rebate == null || product == null)
        {
            result.Success = false;
        }
        else
        {
            var incentiveCalculation = IncentiveCalculationFactory.Create(rebate, product, request);
            if (!rebateIncentiveSupportedByProduct(rebate, product) || !incentiveCalculation.Validate())
            {
                result.Success = false;
            }
            else
            {
                rebateAmount = incentiveCalculation.CalculateRebate();
                result.Success = true;
            }
        }

        if (result.Success)
        {
            var storeRebateDataStore = new RebateDataStore();
            storeRebateDataStore.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }

    private bool rebateIncentiveSupportedByProduct(Rebate rebate, Product product)
    {
        var flag = 1 << (int)rebate.Incentive;
        return product.SupportedIncentives.HasFlag((SupportedIncentiveType)flag);
        
    }
}
