using System.Collections.Generic;

namespace PriceCalculation
{
    public interface ICalculator
    {
        decimal Calculate(IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>> contents);
    }
}
