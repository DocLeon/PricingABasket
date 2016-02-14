namespace PricingABasket
{
    public class PricingConsole
    {
        private readonly IBasketBuilder _basketBuilder;
        private readonly IConsoleWriter _consoleWriter;
        private IBasket _pricedBasket = new Basket();

        public PricingConsole(IBasketBuilder basketBuilder, IConsoleWriter consoleWriter)
        {
            _basketBuilder = basketBuilder;
            _consoleWriter = consoleWriter;
        }

        public void Input(string input)
        {
            _pricedBasket = _basketBuilder.PricedBasketFor(input);
        }

        public void Output()
        {
            _consoleWriter.Write(string.Format("{0}\r\n{1}\r\n{2}", _pricedBasket.SubTotal(), _pricedBasket.DiscountApplied(), _pricedBasket.Total()));
        }
    }
}