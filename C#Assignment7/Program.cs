using C_Assignment7;
using System.Diagnostics.Contracts;

namespace C_Assignment06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part 01:
            //Question 1
            // A) Abstraction means hiding unnecessary implementation details and showing only the essential features of an object.
            // B) because it helps:
            //      Reduce complexity by hiding unnecessary details.
            //      Improve code organization by separating what an object does from how it does it.
            //      Improve security by preventing direct access to internal implementation.
            //      Make code easier to maintain and extend

            //Question 2
            // A) Abstract Class can have both abstract and non-abstract members, while an interface can only have abstract members. Abstract classes can provide default implementations for some methods, while interfaces cannot. A class can inherit from only one abstract class, but it can implement multiple interfaces.
            // B) Choose an interface when you want to define a common capability or contract that different, potentially unrelated classes can implement.
            // C) class cannot inherit from multiple classes, whether they are abstract or not.

            //Part 02:
            Driver driver = new Driver(
    1,
    "Ahmed Ali",
    "01012345678"
);

            string centerName;

            do
            {
                Console.Write("Enter Center Name: ");
                centerName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(centerName))
                {
                    Console.WriteLine("Center name cannot be empty.");
                }

            } while (string.IsNullOrWhiteSpace(centerName));

            DeliveryCenter center = new DeliveryCenter(centerName);

            center.Driver = driver;

            StandardShipment standardShipment = null;
            ExpressShipment expressShipment = null;
            InternationalShipment internationalShipment = null;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();

                string shipmentType;

                if (i == 0)
                {
                    shipmentType = "Standard";
                }
                else if (i == 1)
                {
                    shipmentType = "Express";
                }
                else
                {
                    shipmentType = "International";
                }

                Console.WriteLine($"===== {shipmentType} Shipment =====");

                string trackingCode;

                do
                {
                    Console.Write("Tracking Code: ");
                    trackingCode = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(trackingCode))
                    {
                        Console.WriteLine("Tracking Code cannot be empty.");
                    }

                } while (string.IsNullOrWhiteSpace(trackingCode));

                string description;

                do
                {
                    Console.Write("Description: ");
                    description = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        Console.WriteLine("Description cannot be empty.");
                    }

                } while (string.IsNullOrWhiteSpace(description));

                decimal weight;

                while (true)
                {
                    Console.Write("Weight: ");

                    if (decimal.TryParse(Console.ReadLine(), out weight) &&
                        weight > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Weight must be greater than 0.");
                }

                decimal deliveryFee;

                while (true)
                {
                    Console.Write("Delivery Fee: ");

                    if (decimal.TryParse(Console.ReadLine(), out deliveryFee) &&
                        deliveryFee > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Delivery Fee must be greater than 0.");
                }

                string city;

                do
                {
                    Console.Write("City: ");
                    city = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(city))
                    {
                        Console.WriteLine("City cannot be empty.");
                    }

                } while (string.IsNullOrWhiteSpace(city));

                string street;

                do
                {
                    Console.Write("Street: ");
                    street = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(street))
                    {
                        Console.WriteLine("Street cannot be empty.");
                    }

                } while (string.IsNullOrWhiteSpace(street));

                int buildingNumber;

                while (true)
                {
                    Console.Write("Building Number: ");

                    if (int.TryParse(Console.ReadLine(), out buildingNumber) &&
                        buildingNumber > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Building Number must be greater than 0.");
                }

                DeliveryAddress address = new DeliveryAddress(
                    city,
                    street,
                    buildingNumber
                );

                if (i == 0)
                {
                    standardShipment = new StandardShipment(
                        trackingCode,
                        description,
                        weight,
                        deliveryFee,
                        address
                    );

                    center.AddShipment(standardShipment);
                }
                else if (i == 1)
                {
                    decimal extraFee;

                    while (true)
                    {
                        Console.Write("Extra Fee: ");

                        if (decimal.TryParse(Console.ReadLine(), out extraFee) &&
                            extraFee >= 0)
                        {
                            break;
                        }

                        Console.WriteLine("Extra Fee must be 0 or greater.");
                    }

                    expressShipment = new ExpressShipment(
                        trackingCode,
                        description,
                        weight,
                        deliveryFee,
                        address,
                        extraFee
                    );

                    center.AddShipment(expressShipment);
                }
                else
                {
                    string destinationCountry;

                    do
                    {
                        Console.Write("Destination Country: ");
                        destinationCountry = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(destinationCountry))
                        {
                            Console.WriteLine("Destination Country cannot be empty.");
                        }

                    } while (string.IsNullOrWhiteSpace(destinationCountry));

                    decimal customsFee;

                    while (true)
                    {
                        Console.Write("Customs Fee: ");

                        if (decimal.TryParse(Console.ReadLine(), out customsFee) &&
                            customsFee >= 0)
                        {
                            break;
                        }

                        Console.WriteLine("Customs Fee must be 0 or greater.");
                    }

                    internationalShipment = new InternationalShipment(
                        trackingCode,
                        description,
                        weight,
                        deliveryFee,
                        address,
                        destinationCountry,
                        customsFee
                    );

                    center.AddShipment(internationalShipment);
                }
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("           ALL SHIPMENTS");
            Console.WriteLine("==========================================");

            center.PrintAllShipments();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("        TRACKING STATUSES");
            Console.WriteLine("==========================================");

            center.PrintTrackingStatuses();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("         INSURANCE COSTS");
            Console.WriteLine("==========================================");

            for (int i = 0; i < center.Shipments.Length; i++)
            {
                if (center.Shipments[i] != null)
                {
                    IInsurable shipment = center.Shipments[i] as IInsurable;

                    if (shipment != null)
                    {
                        DeliveryReport.PrintInsurance(shipment);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("          ITrackable[] ARRAY");
            Console.WriteLine("==========================================");

            ITrackable[] trackableShipments =
            {
    standardShipment,
    expressShipment,
    internationalShipment
};

            for (int i = 0; i < trackableShipments.Length; i++)
            {
                Console.WriteLine(
                    trackableShipments[i].GetTrackingStatus()
                );
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("          IInsurable[] ARRAY");
            Console.WriteLine("==========================================");

            IInsurable[] insurableShipments =
            {
    standardShipment,
    expressShipment,
    internationalShipment
};

            for (int i = 0; i < insurableShipments.Length; i++)
            {
                Console.WriteLine(
                    $"Insurance Cost: {insurableShipments[i].CalculateInsurance()}"
                );
            }

        }

    }
    }
