using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Commands.Create;
using System;

namespace RentEasy.Tests.Commands
{
    [TestClass]
    public class CreatePhotoCommandCommand
    {
        [TestMethod]
        public void ComandoDeveSerValido()
        {
            var command = new CreatePhotoCommand("Base64", "JPG", Guid.NewGuid());
            Assert.IsTrue(command.Valid);
        }

        [TestMethod]
        public void ComandoDeveSerInvalido()
        {
            var command = new CreatePhotoCommand("", "JPG", Guid.NewGuid());
            command.Validate();
            Assert.IsTrue(command.Invalid);
        }
    }
}
