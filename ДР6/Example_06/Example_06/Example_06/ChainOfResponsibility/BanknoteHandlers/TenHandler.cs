namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public class TenHandler : BanknoteHandler
    {
        public TenHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        protected override int Value => 10;
    }
}
