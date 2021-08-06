using System;
using System.Collections.Generic;

namespace PriceCalculation
{
    public class Basket
    {
        private readonly ICalculator _calculator;

        public Basket(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public Dictionary<Item, int> Contents  => new Dictionary<Item, int>();

        public Basket AddItem(Item item, int quantity)
        {
            if(!(item == null || quantity == 0))
            {
                if (Contents.ContainsKey(item))
                    Contents[item] += quantity;
                else
                    Contents[item] = quantity;
            }

            return this;
        }

        public decimal GetTotal()
        {
            return _calculator.Calculate(Contents);
        }
    }
}
