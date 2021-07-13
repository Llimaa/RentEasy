using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Commands.Create;
using RentEasy.Domain.ValueObjects;
using System;

namespace RentEasy.Tests.Commands
{
    [TestClass]
    public class CreateHouseCommandTests
    {
        [TestMethod]
        public void CommandDeveSerValido()
        {
            var address = new Address("Rua nova", "1022", "Centro", "Canaa", "Pará", "68537000");
            var command = new CreateHouseCommand("Descrição Casa", 1500, Guid.NewGuid(), "RUa", "100", "Centro", "Canaã", "Para", "68537000");
            command.Validate();
            Assert.IsTrue(command.Valid);
        }

        public void CommandDeveSerInvalido()
        {
            var command = new CreateHouseCommand("Descrição Casa", 0, Guid.NewGuid(), "", "100", "", null, "Para", "68537000");
            command.Validate();
            Assert.IsFalse(command.Valid);
        }
    }
}
