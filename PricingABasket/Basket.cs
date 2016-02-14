using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PricingABasket
{
    public class Basket : IBasket
    {
        private readonly Dictionary<string, int> _prices;
        private readonly List<Discount> _discounts;
        private List<Discount> _discountsApplied = new List<Discount>();
        private string[] _items;
        private int _subTotal;
        private int _totalDiscount;

        public Basket()
        {
            _prices = new Dictionary<string, int>
                {
                    {"", 0},
                    {"Soup", 65},
                    {"Bread", 80},
                    {"Milk", 130},
                    {"Apples", 100}
                };
            _discounts = new List<Discount> {new Discount("Soup",
                                                          2, 50,_prices,"Bread","Bread 50% off with 2 Soups"), 
                                             new Discount("Apples", 1,
                                                          10, _prices,"Apples","Apples 10% off")};
        }

        public void Price(string basketContent)
        {
            _items = basketContent.Split(' ');    
            _subTotal = _items.Sum(item => _prices[item]);
            _discountsApplied = _discounts.Select(discount => discount).Where(discount => discount.Qualifies(_items)).ToList();
            _totalDiscount = _discounts.Sum(discount => discount.DiscountFor(_items));
        }

        public string SubTotal()
        {
            return FormatOutput(_subTotal, "Subtotal: ");
        }

        private static string FormatOutput(int amount, string description)
        {
            return amount < 100 ? string.Format("{1}{0}p", amount, description) 
                                : string.Format("{1}£{0:0.00}", amount/100m, description);
        }

        public string DiscountApplied()
        {
            var discounts = new StringBuilder();
            foreach (var line in _discountsApplied.Select(
                discount => FormatOutput(discount.DiscountFor(_items),
                                         string.Format("{0}: -", discount.Offer))))
            {
                discounts.AppendLine(line);
            }
            return discounts.ToString();
        }

        public string Total()
        {
            return FormatOutput(_subTotal - _totalDiscount,"Total: ");
        }
    }
}