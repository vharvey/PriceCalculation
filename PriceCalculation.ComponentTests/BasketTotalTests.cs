using FluentAssertions;
using PriceCalculation.Offers;
using System;
using Xunit;

namespace PriceCalculation.ComponentTests
{
    public class BasketTotalTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 2, 0, 3.1)]
        [InlineData(0, 0, 4, 3.45)]
        [InlineData(1, 2, 8, 9)]
        public void Given_BasketContainsGivenItems_Then_BasketTotalIsAsExpected(int breadCount, int butterCount, int milkCount, decimal expectedTotal)
        {
            var calculator = new BasketCalculator(new ICalculator[] { new TwoButterFiftyPercentOffBreadOffer(), new GetFourthMilkFreeOffer() });
            var basket = new Basket(calculator)
                .AddItem(Products.Bread, 1m, breadCount)
                .AddItem(Products.Butter, 0.8m, butterCount)
                .AddItem(Products.Milk, 1.15m, milkCount);

            var total = basket.GetTotal();

            total.Should().Be(expectedTotal);
        }
    }
}
