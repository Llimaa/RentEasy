using RentEasy.Domain.Enuns;
using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentEasy.Domain.Entities
{
    public class House : Entity
    {

        private IList<Photo> _photos;

        public House()
        {

        }
        public House(string descricao, decimal rentAmount, Address address, Guid profileId)
        {
            Descricao = descricao;
            Address = address;
            Status = StatusHouse.Desalugada;
            RentAmount = rentAmount;
            ProfileId = profileId;
            _photos = new List<Photo>();
        }

        public string Descricao { get; private set; }
        public Address Address { get; private set; }
        public StatusHouse Status { get; private set; }
        public decimal RentAmount { get; private set; }
        public IReadOnlyCollection<Photo> Photos
        {
            get { if (_photos != null) return _photos.ToArray(); else return new List<Photo>(); }
        }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }
        public Guid TenantId { get; private set; }
        public Tenant Tenant { get; private set; }

        public Guid PhotoId { get; private set; }
        public Photo Photo { get; private set; }

        public void Update(string descricao)
        {
            Descricao = descricao;
        }

        public void UpdateAddess(Address address)
        {
            Address = address;
        }

        public void UpdateStatus(StatusHouse status)
        {
            Status = status;
        }
        public void UpdateRentAmount(decimal value)
        {
            RentAmount = value;
        }
    }
}
