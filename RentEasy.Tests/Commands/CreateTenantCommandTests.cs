using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Commands.Create;
using System;

namespace RentEasy.Tests.Commands
{
    [TestClass]
    public class CreateTenantCommandTests
    {
        [TestMethod]
        public void ComandoDeveSerValido()
        {
            var command = new CreateTenantCommand("Limaa", "94992595694", 25, Guid.NewGuid());
            command.Validate();
            Assert.IsTrue(command.Valid);
        }

        [TestMethod]
        public void ComandoDeveSerInvalido()
        {
            var command = new CreateTenantCommand("", "", 25, Guid.NewGuid());
            command.Validate();
            Assert.IsTrue(command.Invalid);
        }
    }
}
