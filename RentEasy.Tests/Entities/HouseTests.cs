using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Enuns;
using RentEasy.Domain.ValueObjects;

namespace RentEasy.Tests.Entities
{
    [TestClass]
    public class HouseTests
    {
        private readonly Address _address;
        private readonly Profile _profile;
        private readonly House _house;

        public HouseTests()
        {
            _address = new Address("Libano", "121", "Centro", "Belém", "Pará", "68537000");
            _profile = new Profile("Marcos", "991496312", _address);
            _house = new House("Descricao Casa", 5000, _address, _profile.Id);
        }

        [TestMethod]
        public void AoCriarACasaOIDNaoPodeSerNull()
        {
            Assert.IsNotNull(_house.Id);
        }

        [TestMethod]
        public void AoCriarACasaOAlugueuDeveSer5000Reais()
        {
            Assert.AreEqual(_house.RentAmount, 5000);
        }


        [TestMethod]
        public void AoAtualizarADescricaoDeveMudar()
        {
            _house.Update("Atualzando descrição");
            Assert.AreNotEqual(_house.Descricao, "Descricao Casa");
        }

        [TestMethod]
        public void AoCriarACasaOStatusDeveSerDesalugada()
        {
            Assert.AreEqual(_house.Status, StatusHouse.Desalugada);
        }

        [TestMethod]
        public void AoAtualizarOStatusDeveFicarIGualAAlugado()
        {
            _house.UpdateStatus(StatusHouse.Alugada);
            Assert.AreEqual(_house.Status, StatusHouse.Alugada);
        }

        [TestMethod]
        public void AoAtualizarValorAluguelDeveSer1000()
        {
            _house.UpdateRentAmount(100);
            Assert.AreEqual(100, _house.RentAmount);
        }
    }
}
