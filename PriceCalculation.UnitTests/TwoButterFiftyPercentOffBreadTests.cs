using FluentAssertions;
using PriceCalculation.Offers;
using System.Collections.Generic;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class TwoButterFiftyPercentOffBreadTests
    {
        [Fact]
        public void BasketIsNull_DiscountIsZero()
        {
            var offer = new TwoButterFiftyPercentOffBreadOffer();

            var discount = offer.Calculate(null);

            discount.Should().Be(0m);
        }

        [Fact]
        public void BasketIsEmpty_DiscountIsZero()
        {
            var offer = new TwoButterFiftyPercentOffBreadOffer();

            var discount = offer.Calculate(new KeyValuePair<string, (decimal, int)>[0]);

            discount.Should().Be(0m);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(2, 1, 0.6)]
        [InlineData(3, 1, 0.6)]
        [InlineData(2, 2, 0.6)]
        [InlineData(4, 2, 1.2)]
        [InlineData(2, 4, 0.6)]
        public void DiscountsOneBreadForEveryTwoButter(int butterCount, int breadCount, decimal expectedDiscount)
        {
            var basket = new[] 
            {
                new KeyValuePair<string, (decimal unitPrice, int quantity)>(Products.Butter, (0.5m, butterCount)),
                new KeyValuePair<string, (decimal unitPrice, int quantity)>(Products.Bread, (1.2m, breadCount))
            };

            var offer = new TwoButterFiftyPercentOffBreadOffer();

            var discount = offer.Calculate(basket);

            discount.Should().Be(expectedDiscount);
        }
    }
}
