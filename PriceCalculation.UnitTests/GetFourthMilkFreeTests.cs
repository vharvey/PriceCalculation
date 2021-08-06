using FluentAssertions;
using PriceCalculation.Offers;
using System.Collections.Generic;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class GetFourthMilkFreeTests
    {
        private const decimal milkPrice = 1.75m;

        [Fact]
        public void BasketIsNull_DiscountIsZero()
        {
            var offer = new GetFourthMilkFreeOffer();

            var discount = offer.Calculate(null);

            discount.Should().Be(0m);
        }

        [Fact]
        public void BasketIsEmpty_DiscountIsZero()
        {
            var offer = new GetFourthMilkFreeOffer();

            var discount = offer.Calculate(new KeyValuePair<string, (decimal, int)>[0]);

            discount.Should().Be(0m);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 1.75)]
        [InlineData(5, 1.75)]
        [InlineData(7, 1.75)]
        [InlineData(8, 3.5)]
        [InlineData(9, 3.5)]
        public void DiscountsEveryFourthMilk(int milkCount, decimal expectedDiscount)
        {
            var basket = new[] { new KeyValuePair<string, (decimal unitPrice, int quantity)>(Products.Milk, (milkPrice, milkCount)) };

            var offer = new GetFourthMilkFreeOffer();

            var discount = offer.Calculate(basket);

            discount.Should().Be(expectedDiscount);
        }
    }
}
