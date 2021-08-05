using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class GetFourthMilkFreeTests
    {
        private const decimal milkPrice = 1.75m;

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
            true.Should().BeFalse();
        }
    }
}
