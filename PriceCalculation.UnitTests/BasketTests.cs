using FluentAssertions;
using System;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class BasketTests
    {
        [Fact]
        public void Constructor_CalculatorIsNull_ThrowsArgumentNullException()
        {
            true.Should().BeFalse();
        }

        [Fact]
        public void BasketIsEmpty_TotalIsZero()
        {
            true.Should().BeFalse();
        }

        [Fact]
        public void BasketIsNotEmpty_PassesContentsToCalculator()
        {
            true.Should().BeFalse();
        }
    }
}
