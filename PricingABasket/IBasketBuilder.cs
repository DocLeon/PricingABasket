namespace PricingABasket
{
    public interface IBasketBuilder
    {
        IBasket PricedBasketFor(string someInput);
    }
}