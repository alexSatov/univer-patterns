namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public class ThousandHandler : BanknoteHandler
    {
        public ThousandHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int Value => 1000;
    }
}
