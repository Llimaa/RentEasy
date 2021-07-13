using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.ValueObjects;

namespace RentEasy.Tests.Commands
{
    [TestClass]
    public class CreateProfileCommandTestes
    {
        [TestMethod]
        public void ComandoDeveSerValido()
        {
            var address = new Address("Rua nova", "1022", "Centro", "Canaa", "Pará", "68537000");
            var command = new CreateProfileCommand("marcos", "9499495023", "RUa", "100", "Centro", "Canaã", "Para", "68537000");
            command.Validate();
            Assert.IsTrue(command.Valid);
        }

        [TestMethod]
        public void ComandoDeveSerInvalido()
        {
            var address = new Address("Rua nova", "1022", "Centro", "Canaa", "Pará", "68537000");
            var command = new CreateProfileCommand("", "9499495023", "RUa", "100", "Centro", "Canaã", "Para", "68537000");
            command.Validate();
            Assert.IsFalse(command.Valid);
        }
    }
}
