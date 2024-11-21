using System;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        switch (productIdentifier)
        {
            case "TestProduct1":
                return new Product()
                {
                    Id = 1,
                    Identifier = "TestProduct1",
                    Price = 10m,
                    Uom = "kg",
                    SupportedIncentives = SupportedIncentiveType.FixedRateRebate
                };
            case "TestProduct2":
                return new Product()
                {
                    Id = 2,
                    Identifier = "TestProduct2",
                    Price = 10m,
                    Uom = "kg",
                    SupportedIncentives = SupportedIncentiveType.FixedCashAmount | SupportedIncentiveType.AmountPerUom
                };
            default:
                return null;
        }
        
    }
}
