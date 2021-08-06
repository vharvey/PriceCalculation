using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculation.UnitTests
{
    public class BasketCalculatorTests
    {
        [Fact]
        public void Calculate_NoOffers_ReturnsContentsTotal()
        {
            var items = new Dictionary<Item, int>
            {
                { new Item("one", 1m), 10 },
                { new Item("two", 2m), 15 },
                { new Item("three", 2.5m), 3 }
            };

            var calculator = new BasketCalculator(null);

            var total = calculator.Calculate(items);

            total.Should().Be(47.5m);
        }

        [Fact]
        public void Calculate_SubtractsDiscountsFromContentsTotal()
        {
            var items = new Dictionary<Item, int>
            {
                { new Item("one", 1m), 10 },
                { new Item("two", 2m), 15 },
                { new Item("three", 2.5m), 3 }
            };
            var offers = new Mock<ICalculator>();
            offers.SetupSequence(o => o.Calculate(It.IsAny<IEnumerable<KeyValuePair<Item, int>>>()))
                .Returns(2m)
                .Returns(0.25m);

            var calculator = new BasketCalculator(new[] { offers.Object, offers.Object });

            var total = calculator.Calculate(items);

            total.Should().Be(45.25m);
        }

        [Fact]
        public void Calculate_PassesContentsToOffers()
        {
            var items = new Dictionary<Item, int>
            {
                { new Item("one", 1m), 10 },
                { new Item("two", 2m), 15 },
                { new Item("three", 2.5m), 3 }
            };
            var offers = new Mock<ICalculator>();
            offers.Setup(o => o.Calculate(It.IsAny<IEnumerable<KeyValuePair<Item, int>>>()));

            var calculator = new BasketCalculator(new[] { offers.Object, offers.Object });

            var total = calculator.Calculate(items);

            offers.Verify(o => o.Calculate(It.Is<IEnumerable<KeyValuePair<Item,int>>>(x => x == items)), Times.Exactly(2));
        }
    }
}
