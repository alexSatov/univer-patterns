namespace Example_06.ChainOfResponsibility.BanknoteHandlers
{
    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;
        protected abstract int Value { get; }

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual bool Validate(ref string money, out string banknotes)
        {
            var amount = int.Parse(money);
            var banknoteCount = amount/Value;
            money = (amount % Value).ToString();
            var cache = banknoteCount == 0 ? "" : $"{Value}x{banknoteCount}";

            if (_nextHandler != null && money != "0")
            {
                if (!_nextHandler.Validate(ref money, out banknotes))
                    return false;
                cache = cache == "" ? banknotes : cache + " + " + banknotes;
            }

            banknotes = cache;
            return money == "0";
        }
    }
}
