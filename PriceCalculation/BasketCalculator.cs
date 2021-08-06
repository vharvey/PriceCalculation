using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation
{
    public class BasketCalculator : ICalculator
    {
        public decimal Calculate(IEnumerable<KeyValuePair<Item, int>> contents)
        {
            throw new NotImplementedException();
        }
    }
}
