using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Enuns;
using RentEasy.Domain.ValueObjects;
using System;

namespace RentEasy.Tests.Entities
{
    [TestClass]
    public class TenantTests
    {

        private readonly Address _address;
        private readonly Profile _profile;
        private readonly House _house;
        private readonly Tenant _tenant;

        public TenantTests()
        {
            _address = new Address("Libano", "121", "Centro", "Belém", "Pará", "68537000");
            _profile = new Profile("Marcos", "991496312", _address);
            _house = new House("Esta é uma casa nova, pronta para alugar.", 5000, _address, _profile.Id);
            _tenant = new Tenant("Lima", "94991496012", 10, _house.Id);
        }
        [TestMethod]
        public void AoCriarInquilinoDeveFicarComStatusPaymentIGualAPaidOut()
        {
            Assert.AreEqual(_tenant.StatusPayment, StatusPayment.PaidOut);
        }
        [TestMethod]
        public void AoCriarInquilinoDeveFicarComStatusActive()
        {
            Assert.AreEqual(_tenant.StatusTenant, StatusTenant.Active);
        }
        [TestMethod]
        public void AoCriarInquilinoADateStartDeveSerADoDiaAtual()
        {
            Assert.AreEqual(_tenant.DateStart.Date, DateTime.Now.Date);
        }

        [TestMethod]
        public void AoAtualizarStatusPagamentoDeveSerLate()
        {
            _tenant.UpdateStatusPayment(StatusPayment.Late);
            Assert.AreEqual(_tenant.StatusPayment, StatusPayment.Late);
        }

        [TestMethod]
        public void AoAtualizarStatusTenantEleDeveSerDesactive()
        {
            _tenant.TenantExit();
            Assert.AreEqual(_tenant.StatusTenant, StatusTenant.Desactive);
        }

        [TestMethod]
        public void DeveRetornar2DiasDeAtraso()
        {
            _tenant.UpdateLastPaymentDate(DateTime.Now.AddDays(-3));
            var res = _tenant.HowManyDaysOfLate();
            Assert.AreEqual(res, -2);
        }
    }
}
