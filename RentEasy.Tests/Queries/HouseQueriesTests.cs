using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using RentEasy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentEasy.Tests.Queries
{

    [TestClass]
    public class HouseQueriesTests
    {
        private IList<House> _houses;
        private static Guid _idProfile = Guid.NewGuid();

        public HouseQueriesTests()
        {
            _houses = new List<House>();
            var address = new Address("Street", "100", "Centro", "Canaa", "Pará", "68537000");
            _houses.Add(new House("Description house 01", 1000, address, _idProfile));
            _houses.Add(new House("Description house 02", 2400, address, _idProfile));
            _houses.Add(new House("Description house 03", 2122, address, _idProfile)); ;
            _houses.Add(new House("Description house 04", 500, address, Guid.NewGuid()));
            _houses.Add(new House("Description house 05", 333, address, Guid.NewGuid()));
        }

        [TestMethod]
        public void DadoAConsultaGetByIdRetornarUmItem()
        {
            var result = _houses.AsQueryable().Where(HouseQueries.GetById(_houses[0].Id));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DadoAConsultaGetHousersByIdProfileDeveRetornarTresItens()
        {
            var result = _houses.AsQueryable().Where(HouseQueries.GetHousersByIdProfile(_idProfile));
            Assert.AreEqual(3, result.Count());
        }
    }
}
