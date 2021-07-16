using RentEasy.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEasy.Domain.ValueObjects
{
    public class Email: ValueObject
    {
        public Email()
        {

        }
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}
