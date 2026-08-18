using C_Assignment06;
using System;

namespace C_Assignment07
{
    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination,
                destinationCountry,
                customsFee)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("----- Priority Customs Report -----");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee        : {CustomsFee}");
            Console.WriteLine("Priority Shipment");
            Console.WriteLine("-----------------------------------");
        }
    }
}