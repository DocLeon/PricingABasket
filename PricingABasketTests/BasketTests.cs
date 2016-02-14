using NUnit.Framework;
using PricingABasket;

namespace PricingABasketTests
{
    [TestFixture]
    public class BasketTests
    {
        private readonly Basket _basket = new Basket();

        [TestCase("","0p")]
        [TestCase("Soup", "65p")]
        [TestCase("Bread", "80p")]
        [TestCase("Milk", "£1.30")]
        [TestCase("Apples", "£1.00")]
        [TestCase("Apples Apples","£2.00")]
        public void it_prices_items_in_the_basket(string items, string subtotal)
        {
            _basket.Price(items);
            Assert.That(_basket.SubTotal(), Is.EqualTo(string.Format("Subtotal: {0}",subtotal)));
        }

        [Test]
        public void it_applies_discounts_on_apples()
        {
            _basket.Price("Apples");
            Assert.That(_basket.DiscountApplied(),Is.EqualTo("Apples 10% off: -10p\r\n"));
        }

        [Test]
        public void it_applies_discount_on_bread_when_two_tins_of_soup_purchased()
        {
            _basket.Price("Soup Soup Bread");
            Assert.That(_basket.DiscountApplied(), Is.EqualTo("Bread 50% off with 2 Soups: -40p\r\n"));
        }

        [Test]
        public void it_applies_multiple_discounts()
        {
            _basket.Price("Soup Soup Bread Apples");
            Assert.That(_basket.DiscountApplied(), Is.EqualTo(@"Bread 50% off with 2 Soups: -40p
Apples 10% off: -10p
"));
        }

        [Test]
        public void it_returns_subtotal()
        {
            _basket.Price("Apples");
            Assert.That(_basket.SubTotal(), Is.EqualTo("Subtotal: £1.00"));
        }

        [Test]
        public void it_returns_total()
        {
            _basket.Price("Bread");
            Assert.That(_basket.Total(), Is.EqualTo("Total: 80p") );
        }
    }
}
