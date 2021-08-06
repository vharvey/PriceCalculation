using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.Offers
{
    public class TwoButterFiftyPercentOffBreadOffer : ICalculator
    {
        public decimal Calculate(IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>> contents)
        {
            if (!(contents?.Any() == true))
                return 0m;

            var breadItems = contents.Where(x => x.Key == Products.Bread);
            if (!breadItems.Any())
                return 0m;

            var breadPrice = breadItems.First().Value.unitPrice;

            var breadCount = breadItems
                .Sum(x => x.Value.quantity);

            var maxDiscountedBread = contents.Where(x => x.Key == Products.Butter)
                .Sum(x => x.Value.quantity) / 2;

            var discountedBread = Math.Min(maxDiscountedBread, breadCount);
            
            return discountedBread * breadPrice / 2;
        }
    }
}
