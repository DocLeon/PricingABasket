using Moq;
using NUnit.Framework;
using PricingABasket;

namespace PricingABasketTests
{
    [TestFixture]
    public class PricingConsoleTest
    {
        [Test]
        public void It_parses_input_from_user()
        {
            var basketBuilder = new Mock<IBasketBuilder>();
            var pricingConsole = new PricingConsole(basketBuilder.Object, new Mock<IConsoleWriter>().Object);
            pricingConsole.Input("Some Input");
            basketBuilder.Verify(x => x.PricedBasketFor("Some Input"));
        }

        [Test]
        public void It_writes_output_to_constole()
        {
            var basketBuilder = new Mock<IBasketBuilder>();
            var stubBasket = new Mock<IBasket>();
            stubBasket.Setup(x => x.SubTotal()).Returns("Subtotal");
            stubBasket.Setup(x => x.DiscountApplied()).Returns("Discount");
            stubBasket.Setup(x => x.Total()).Returns("Total");
            var console = new Mock<IConsoleWriter>();
            basketBuilder.Setup(x => x.PricedBasketFor(It.IsAny<string>())).Returns(stubBasket.Object);
            var pricingConsole = new PricingConsole(basketBuilder.Object, console.Object);
            pricingConsole.Input("Some command");
            pricingConsole.Output();
            console.Verify(x => x.Write(@"Subtotal
Discount
Total"));
        }
    }
}
