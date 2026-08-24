using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment7
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string shipmentType = shipment.GetType().Name
                .Replace("Shipment", "");

            return $"{shipment.TrackingCodeProperty} | {shipmentType} | {shipment.WeightProperty} KG | {shipment.GetTrackingStatus()}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingStatus().Contains("Delivered");
        }
    }
}
