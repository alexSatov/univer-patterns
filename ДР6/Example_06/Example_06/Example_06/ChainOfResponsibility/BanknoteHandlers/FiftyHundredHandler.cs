namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public class FiftyHundredHandler : BanknoteHandler
    {
        public FiftyHundredHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int Value => 500;
    }
}
