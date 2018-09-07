using System;
using Example_06.ChainOfResponsibility.BanknoteHandlers;

namespace Example_06.ChainOfResponsibility
{
    public enum CurrencyType
    {
        Euro,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    } 

    public class Bancomat
    {
        private readonly BanknoteHandler dollarHandler;
        private readonly BanknoteHandler rubleHandler;
        private readonly BanknoteHandler euroHandler;

        public Bancomat()
        {
            dollarHandler = new TenHandler(null);
            dollarHandler = new HundredHandler(dollarHandler);
            dollarHandler = new FiftyHundredHandler(dollarHandler);

            euroHandler = new TenHandler(null);
            euroHandler = new FiftyHandler(euroHandler);
            euroHandler = new HundredHandler(euroHandler);

            rubleHandler = new HundredHandler(null);
            rubleHandler = new FiftyHundredHandler(rubleHandler);
            rubleHandler = new ThousandHandler(rubleHandler);
        }

        public string GetBanknotes(string disiredAmountOfMoney)
        {
            string banknotes;

            if (Validate(disiredAmountOfMoney, out banknotes))
                return banknotes == "" ? "0" : banknotes.Replace("x1", "");

            throw new ArgumentException("Invalid amount of money");
        }

        private bool Validate(string desiredAmount, out string banknotes)
        {
            var handler = GetHandlerForBanknote(desiredAmount);
            desiredAmount = desiredAmount.Substring(0, desiredAmount.Length - 1);
            return handler.Validate(ref desiredAmount, out banknotes);
        }

        private BanknoteHandler GetHandlerForBanknote(string banknote)
        {
            switch (banknote[banknote.Length - 1])
            {
                case '$':
                    return dollarHandler;
                case '€':
                    return euroHandler;
                case '₽':
                    return rubleHandler;
                default:
                    throw new ArgumentException("Unknown banknote");
            }
        }
    }
}
