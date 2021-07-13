using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Queries;
using RentEasy.Domain.ValueObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RentEasy.Tests.Queries
{
    [TestClass]
    public class ProfileQueriesTests
    {

        private IList<Profile> _profiles;
        public ProfileQueriesTests()
        {
            _profiles = new List<Profile>();
            _profiles.Add(new Profile("Marcos", "94991329403", new Address("Rua", "1003", "Centro", "Belem", "Para", "68948330")));
            _profiles.Add(new Profile("MarcosLima", "94991329403", new Address("Rua", "1003", "Centro", "Belem", "Para", "68948330")));
        }
        [TestMethod]
        public void DadoAConsultGetByIdDeveRetornarCountIgualA1()
        {
            Assert.AreEqual(1, _profiles.AsQueryable().Where(ProfileQueries.GetById(_profiles[0].Id)).Count());
        }

        public void DadoAConsultGetByIdDeveRetornarNomeIgualAMarcosLima()
        {

            Assert.AreEqual("MarcosLima", _profiles.AsQueryable().Where(ProfileQueries.GetById(_profiles[1].Id)).FirstOrDefault().Name);
        }
    }
}
