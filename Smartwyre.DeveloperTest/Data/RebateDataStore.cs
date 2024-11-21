using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        switch (rebateIdentifier)
        {
            case "TestRebate1":
                return new Rebate()
                {
                    Identifier = "TestRebate1",
                    Incentive = IncentiveType.FixedRateRebate,
                    Percentage = 20
                };
            case "TestRebate2":
                return new Rebate()
                {
                    Identifier = "TestRebate2",
                    Incentive = IncentiveType.AmountPerUom,
                    Amount = 5m
                };
            case "TestRebate3":
                return new Rebate()
                {
                    Identifier = "TestRebate3",
                    Incentive = IncentiveType.FixedCashAmount,
                    Amount = 5m
                };
            default:
                return null;
        }
        
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }
}
