using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Tests.Queries
{
    [TestClass]
    public class PhotoQueriesTests
    {
        private IList<Photo> _photos;
        private static Guid _houseId = Guid.NewGuid();

        public PhotoQueriesTests()
        {
            _photos = new List<Photo>();
            _photos.Add(new Photo("Esta é a data base64", "JPG", _houseId));
            _photos.Add(new Photo("Esta é a data base64", "JPG", _houseId));
            _photos.Add(new Photo("Esta é a data base64", "JPG", Guid.NewGuid()));
        }

        [TestMethod]
        public void DadoAConsultaGetByIdRetornarUmItem()
        {
            var result = _photos.AsQueryable().Where(PhotoQueries.GetById(_photos[0].Id));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DadoAConsultaGetAllPhotoByHouseIdDevedRetornarDoisItens()
        {
            var result = _photos.AsQueryable().Where(PhotoQueries.GetAllPhotoByHouseId(_houseId));
            Assert.AreEqual(2, result.Count());
        }
    }
}
