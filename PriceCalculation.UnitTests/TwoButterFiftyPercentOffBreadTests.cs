using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class TwoButterFiftyPercentOffBreadTests
    {
        private const decimal _breadPrice = 1.2m;

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(2, 2, 0.6)]
        [InlineData(3, 2, 0.6)]
        [InlineData(4, 2, 1.2)]
        public void DiscountsOneLoafOfBreadForEveryTwoButters(int butterCount, int breadCount, decimal expectedDiscount)
        {
            true.Should().BeFalse();
        }
    }
}
