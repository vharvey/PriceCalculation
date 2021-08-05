namespace PriceCalculation
{
    public class Item
    {
        public Item(string name, decimal cost)
        {
            Product = name;
            Cost = cost;
        }
        public string Product { get;  }
        public decimal Cost { get;  }
    }
}
