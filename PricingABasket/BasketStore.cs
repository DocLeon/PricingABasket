namespace PricingABasket
{
    internal class BasketStore : IBasketStore
    {
        public IBasket GetEmptyBasket()
        {
            return new Basket();
        }
    }
}