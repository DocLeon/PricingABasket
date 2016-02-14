using System;

namespace PricingABasket
{
    public class BasketBuilder: IBasketBuilder
    {
        private readonly IBasketStore _basketStore;

        public BasketBuilder(IBasketStore basketStore)
        {
            _basketStore = basketStore;
        }

        public IBasket PricedBasketFor(string input)
        {
            const string priceBasketCommand = "PriceBasket ";
            var basket = _basketStore.GetEmptyBasket();
            var listStart = input.IndexOf(priceBasketCommand, StringComparison.CurrentCulture);
            var list = input.Remove(listStart, priceBasketCommand.Length);
            basket.Price(list);
            return basket;
        }
    }
}