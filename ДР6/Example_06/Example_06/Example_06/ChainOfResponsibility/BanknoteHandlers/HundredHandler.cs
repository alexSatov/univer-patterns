namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public class HundredHandler : BanknoteHandler
    {
        public HundredHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int Value => 100;
    }
}
