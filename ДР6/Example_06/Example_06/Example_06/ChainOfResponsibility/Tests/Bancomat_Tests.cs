using System;
using NUnit.Framework;

namespace Example_06.ChainOfResponsibility.Tests
{
    [TestFixture]
    public class Bancomat_Should
    {
        public static readonly Bancomat Bancomat = new Bancomat();

        [TestCase("1430$", ExpectedResult = "500x2 + 100x4 + 10x3")]
        [TestCase("670€", ExpectedResult = "100x6 + 50 + 10x2")]
        [TestCase("3500₽", ExpectedResult = "1000x3 + 500")]
        public string GiveMoney_WhenCorrectAmount(string amount)
        {
            return Bancomat.GetBanknotes(amount);
        }

        [Test]
        public void Failed_WhenAmoundWithoutMoneySign()
        {
            Assert.Throws(typeof(ArgumentException), () => Bancomat.GetBanknotes("450"));
        }

        [Test]
        public void Failed_WhenInvalidAmound()
        {
            Assert.Throws(typeof(ArgumentException), () => Bancomat.GetBanknotes("454$"));
        }
    }
}
