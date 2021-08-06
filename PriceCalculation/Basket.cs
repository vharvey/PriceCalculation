using System;
using System.Collections.Generic;

namespace PriceCalculation
{
    public class Basket
    {
        private readonly ICalculator _calculator;
        private readonly Dictionary<string, (decimal unitPrice, int quantity)> _contents;

        public Basket(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _contents = new Dictionary<string, (decimal unitPrice, int quantity)>();
        }

        public Basket AddItem(string product, decimal unitPrice, int quantity)
        {
            if (!(string.IsNullOrEmpty(product) || unitPrice == 0m || quantity == 0))
            {
                if (_contents.ContainsKey(product))
                    _contents[product] = (_contents[product].unitPrice, _contents[product].quantity + quantity);
                else
                    _contents.Add(product, (unitPrice, quantity));
            }

            return this;
        }

        public decimal GetTotal()
        {
            return _calculator.Calculate(_contents);
        }
    }
}
