using RentEasy.Shared.Entities;
using System;

namespace RentEasy.Domain.Entities
{
    public class Photo : Entity
    {
        public Photo()
        {

        }
        public Photo(string data, string format, Guid houseId)
        {
            Data = data;
            Format = format;
            HouseId = houseId;
        }

        public string Data { get; private set; }
        public string Format { get; private set; }
        public Guid HouseId { get; set; }
        public House House { get; set; }

        public void Update(string data, string format)
        {
            Data = data;
            Format = format;
        }
    }
}
