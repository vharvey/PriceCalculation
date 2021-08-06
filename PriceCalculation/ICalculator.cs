using System.Collections.Generic;

namespace PriceCalculation
{
    public interface ICalculator
    {
        decimal Calculate(IEnumerable<KeyValuePair<Item, int>> contents);
    }
}
