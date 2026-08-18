using C_Assignment06;
using System;

namespace C_Assignment07
{
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination)
        {
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFeeProperty + (WeightProperty * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("----- Completed Shipment -----");
            Console.WriteLine($"Tracking Code : {TrackingCodeProperty}");
            Console.WriteLine($"Description   : {DescriptionProperty}");
            Console.WriteLine($"Weight        : {WeightProperty}");
            Console.WriteLine($"Delivery Fee  : {DeliveryFeeProperty}");
            Console.WriteLine($"Destination   : {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine("------------------------------");
        }
    }
}