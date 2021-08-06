using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class BasketTests
    {
        [Fact]
        public void Constructor_CalculatorIsNull_ThrowsArgumentNullException()
        {
            Action act = () => new Basket(null);

            act.Should().Throw<ArgumentNullException>()
                .Which.ParamName.Should().Be("calculator");
        }


        [Fact]
        public void GetTotal_PassesConsolidatedContentsToCalculator()
        {
            IEnumerable<KeyValuePair<string, (decimal, int)>> itemList = null;
            var calculator = new Mock<ICalculator>();
            calculator.Setup(c => c.Calculate(It.IsAny<IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>>>()))
                .Callback<IEnumerable<KeyValuePair<string, (decimal, int)>>>((contents) => itemList = contents);

            var basket = new Basket(calculator.Object)
                .AddItem("item one", 12.3m, 1)
                .AddItem("item two", 4.56m, 1)
                .AddItem("item one", 12.3m, 6);

            var total = basket.GetTotal();

            itemList.Should().BeEquivalentTo(new Dictionary<string, (decimal, int)> { { "item one", (12.3m, 7) }, { "item two", (4.56m, 1) } });
        }

        [Fact]
        public void GetTotal_GetsTotalFromCalculator()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(c => c.Calculate(It.IsNotNull<IEnumerable<KeyValuePair<string, (decimal unitPrice, int quantity)>>>()))
                .Returns(123.45m);
            var basket = new Basket(calculator.Object)
                .AddItem("test item", 98.7m, 1);

            var total = basket.GetTotal();

            total.Should().Be(123.45m);
        }
    }
}
