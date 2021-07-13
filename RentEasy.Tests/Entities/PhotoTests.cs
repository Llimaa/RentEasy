using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Tests.Entities
{
    [TestClass]
    public class PhotoTests
    {
        private readonly Photo _photo;
        public PhotoTests()
        {
            _photo = new Photo("base64", "JPG", Guid.NewGuid());
        }
        [TestMethod]
        public void AoCriarUmaFotoDeveTerUmId()
        {
            Assert.IsNotNull(_photo.Id);
        }

        [TestMethod]
        public void AoCriarUmaFotoDeveTerUmHouseId()
        {
            Assert.IsNotNull(_photo.HouseId);
        }

        [TestMethod]
        public void AoAtualizarUmaFotoOIdNaoDeveMudar()
        {
            var id = _photo.Id;
            _photo.Update("Base64 Atualizada", "JPEG");

            Assert.AreEqual(_photo.Id, id);
        }

    }
}
