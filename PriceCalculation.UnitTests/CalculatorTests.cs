using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_NoOffers_ReturnsContentsTotal()
        {
            true.Should().BeFalse();
        }

        [Fact]
        public void Calculate_SubtractsDiscountsFromContentsTotal()
        {
            true.Should().BeFalse();
        }
    }
}
