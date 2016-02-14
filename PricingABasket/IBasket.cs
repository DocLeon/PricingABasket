namespace PricingABasket
{
    public interface IBasket
    {
        void Price(string applesMilkBread);
        string SubTotal();
        string DiscountApplied();
        string Total();
    }
}