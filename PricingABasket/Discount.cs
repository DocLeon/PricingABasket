using System.Collections.Generic;
using System.Linq;

namespace PricingABasket
{
    public class Discount
    {
        private readonly string _itemToTriggerDiscount;
        private readonly int _numberOfItemsNeededToTriggerDiscount;
        private readonly int _percentageDiscount;
        private readonly Dictionary<string,int> _prices;
        private readonly string _itemOnWhichDiscountIsApplied;

        public Discount(string itemToTriggerDiscount, int numberOfItemsNeededToTriggerDiscount, int percentageDiscount, Dictionary<string, int> prices, string itemOnWhichDiscountIsApplied, string offer)
        {
            _itemToTriggerDiscount = itemToTriggerDiscount;
            _numberOfItemsNeededToTriggerDiscount = numberOfItemsNeededToTriggerDiscount;
            _percentageDiscount = percentageDiscount;
            _prices = prices;
            _itemOnWhichDiscountIsApplied = itemOnWhichDiscountIsApplied;
            Offer = offer;
        }

        public string Offer { get; private set; }

        public int DiscountFor(string[] items)
        {
            if (Qualifies(items))
                return _prices[_itemOnWhichDiscountIsApplied] * _percentageDiscount / 100;
            return 0;
        }

        public bool Qualifies(string[] items)
        {
           var numberOfItemsInBasketToTriggerDiscount = items.Select(item => item).Count(item => item == _itemToTriggerDiscount);
           return ((numberOfItemsInBasketToTriggerDiscount % _numberOfItemsNeededToTriggerDiscount == 0
               && (numberOfItemsInBasketToTriggerDiscount >= _numberOfItemsNeededToTriggerDiscount)));
        }
    }
}