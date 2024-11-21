using System;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        RebateService rebateService = new RebateService();

        Console.WriteLine("-- Rebate Calculator --");

        Console.WriteLine("Enter rebate identifier:");
        var rebateIdentifier = Console.ReadLine();

        Console.WriteLine("Enter product identifier:");
        var productIdentifier = Console.ReadLine();

        Console.WriteLine("Enter volume:");
        var volume = 0m;
        if (!decimal.TryParse(Console.ReadLine(), out volume))
        {
            Console.WriteLine("Invalid volume entered.");
        }

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = rebateIdentifier,
            ProductIdentifier = productIdentifier,
            Volume = volume
        };

        var result = rebateService.Calculate(request);
        Console.WriteLine(result.Success ? "Success" : "Failed");
    }
}
