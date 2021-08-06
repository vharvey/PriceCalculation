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
        public void GetTotal_PassesContentsToCalculator()
        {
            IEnumerable<KeyValuePair<Item, int>> itemList = null;
            var calculator = new Mock<ICalculator>();
            calculator.Setup(c => c.Calculate(It.IsAny<IEnumerable<KeyValuePair<Item, int>>>()))
                .Callback<IEnumerable<KeyValuePair<Item, int>>>((contents) => itemList = contents);

            var basket = new Basket(calculator.Object)
                .AddItem(new Item("item one", 12.3m), 1)
                .AddItem(new Item("item two", 4.56m), 1);

            var total = basket.GetTotal();

            itemList.Should().BeEquivalentTo(basket.Contents);
        }

        [Fact]
        public void GetTotal_GetsTotalFromCalculator()
        {
            var calculator = new Mock<ICalculator>();
            calculator.Setup(c => c.Calculate(It.IsNotNull<IEnumerable<KeyValuePair<Item, int>>>()))
                .Returns(123.45m);
            var basket = new Basket(calculator.Object)
                .AddItem(new Item("test item", 98.7m), 1);

            var total = basket.GetTotal();

            total.Should().Be(123.45m);
        }
    }
}
