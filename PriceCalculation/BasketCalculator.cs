using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class BasketCalculator : ICalculator
    {
        private readonly List<ICalculator> _offers = new List<ICalculator>();

        public BasketCalculator(IEnumerable<ICalculator>offers)
        {
            if (offers != null)
                _offers.AddRange(offers);
        }

        public decimal Calculate(IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>> contents)
        {
            if (contents == null || !contents.Any())
                return 0m;


            var discountTotal = _offers.Aggregate(0m, (total, next) => total += next.Calculate(contents));

            return contents.Sum(basketItem => basketItem.Value.unitPrice * basketItem.Value.quantity) - discountTotal;
        }
    }
}
