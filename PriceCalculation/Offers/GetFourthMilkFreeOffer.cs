using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Offers
{
    public class GetFourthMilkFreeOffer : ICalculator
    {
        public decimal Calculate(IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>> contents)
        {
            if (!(contents?.Any() == true))
                return 0m;
        
            var totalMilk = contents.Where(x => x.Key == Products.Milk)
                .Sum(x => x.Value.quantity);

            var freeItems = totalMilk / 4;
            var unitPrice = contents.FirstOrDefault(x => x.Key == Products.Milk).Value.unitPrice;

            return freeItems * unitPrice;
        }
    }
}
