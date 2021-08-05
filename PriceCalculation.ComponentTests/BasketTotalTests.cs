using FluentAssertions;
using System;
using Xunit;

namespace PriceCalculation.ComponentTests
{
    public class BasketTotalTests
    {
        private const decimal _butterPrice = 0.8m;
        private const decimal _milkPrice = 1.15m;
        private const decimal _breadPrice = 1m;

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 2, 0, 3.1)]
        [InlineData(0, 0, 4, 3.45)]
        [InlineData(2, 1, 8, 9)]
        public void Given_BasketContainsGivenItems_Then_BasketTotalIsAsExpected(int breadCount, int butterCount, int milkCount, decimal expectedTotal)
        {
            var bread = new Item("bread", 1m);
            var butter = new Item("butter", 0.8m);
            var milk = new Item("milk", 1.15m);

            var basket = new Basket()
                .AddItem(bread, breadCount)
                .AddItem(butter, butterCount)
                .AddItem(milk, milkCount);

            var total = basket.GetTotal();

            total.Should().Be(expectedTotal);
        }
    }
}
