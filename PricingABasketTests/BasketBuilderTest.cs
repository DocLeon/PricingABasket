using Moq;
using NUnit.Framework;
using PricingABasket;

namespace PricingABasketTests
{
    [TestFixture]
    public class BasketBuilderTest
    {
        private Mock<IBasketStore> _basketStore;
        private Mock<IBasket> _basket;

        [SetUp]
        public void SetUp()
        {
            _basketStore = new Mock<IBasketStore>();
            _basket = new Mock<IBasket>();
            _basketStore.Setup(x => x.GetEmptyBasket()).Returns(_basket.Object);
            var basketBuilder = new BasketBuilder(_basketStore.Object);
            basketBuilder.PricedBasketFor("PriceBasket Apples Milk Bread");
        }

        [Test]
        public void It_prices_the_basket()
        {
            _basket.Verify(x=>x.Price("Apples Milk Bread"));
        }

        [Test]
        public void It_gets_an_empty_basket()
        {
            _basketStore.Verify(x => x.GetEmptyBasket());
        }
    }
}
