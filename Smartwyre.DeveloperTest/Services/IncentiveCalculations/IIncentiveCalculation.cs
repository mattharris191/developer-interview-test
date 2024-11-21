using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public interface IIncentiveCalculation
{
    public bool Validate();

    public decimal CalculateRebate();
}
