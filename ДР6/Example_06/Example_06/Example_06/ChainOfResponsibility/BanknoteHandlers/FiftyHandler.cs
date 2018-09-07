namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public class FiftyHandler : BanknoteHandler
    {
        public FiftyHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int Value => 50;
    }
}
