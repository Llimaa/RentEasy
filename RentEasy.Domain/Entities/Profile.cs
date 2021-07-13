using RentEasy.Domain.ValueObjects;
using RentEasy.Shared.Entities;
using System.Collections.Generic;

namespace RentEasy.Domain.Entities
{
    public class Profile : Entity
    {
        public Profile()
        {

        }
        public Profile(string name, string phone, Address address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public Address Address { get; private set; }
        public IList<House> Houses { get; private set; }

        public void Update(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
