using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment06
{
    public class DeliveryAddress
    {
        public string city;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            this.city = city;
            this.Street = street;
            this.BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return $"{this.BuildingNumber}, {this.Street}, {this.city}";
        }
    }
}
