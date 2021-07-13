using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentEasy.Tests.Queries
{
    [TestClass]
    public class TenantQueriesTests
    {
        private IList<Tenant> _tenants;
        private static Guid _idHouse = Guid.NewGuid();

        public TenantQueriesTests()
        {
            _tenants = new List<Tenant>();
            _tenants.Add(new Tenant("Marcos Lima", "94991495832", 10, _idHouse));
            _tenants.Add(new Tenant("Marcos Lima", "94991495832", 10, _idHouse));
            _tenants.Add(new Tenant("Marcos Lima", "94991495832", 10, _idHouse));
            _tenants.Add(new Tenant("Marcos Lima", "94991495832", 10, Guid.NewGuid()));
            _tenants.Add(new Tenant("Marcos Lima", "94991495832", 10, Guid.NewGuid()));
        }

        [TestMethod]
        public void DadoAConsultaGetByIdRetornarUmItem()
        {
            var result = _tenants.AsQueryable().Where(TenantQueries.GetById(_tenants[0].Id));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DadoAConsultaGetTenantByHouseIdRetornarTresItens()
        {
            var result = _tenants.AsQueryable().Where(TenantQueries.GetTenantByHouseId(_idHouse));
            Assert.AreEqual(3, result.Count());
        }
    }
}
