using C_Assignment7;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment06
{
    public class DeliveryCenter
    {
        private Shipment[] shipments;

        public string CenterName { get; set; }
        public Driver Driver { get; set; }

        public Shipment[] Shipments
        {
            get { return shipments; }
        }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
            shipments = new Shipment[20];
        }
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }

                return default;
            }

            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null &&
                        shipments[i].TrackingCodeProperty == trackingCode)
                    {
                        return shipments[i];
                    }
                }

                return default;
            }
        }
        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCodeProperty == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }

            return false;
        }
        public void PrintAllShipments()
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    shipments[i].PrintShipment();
                }
            }
        }

        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    ITrackable shipment = shipments[i] as ITrackable;

                    if (shipment != null)
                    {
                        Console.WriteLine(shipment.GetTrackingStatus());
                    }
                }
            }
        }
    }
}
