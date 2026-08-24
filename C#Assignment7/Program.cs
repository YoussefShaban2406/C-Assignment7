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
            // A) the refernce is copied not the actual object.
            // B) Assigning one object variable to another does not create a new object.
            // C) Copying a reference: Both variables point to the same object Copying an object: A new, separate object is created with the same data(usually called a deep / shallow copy depending on how the copying is performed).

            //Question 2
            // A) Shallow Copy creates a new object, but it copies the values of the original object's members as they are. For reference-type members, it copies the reference, not the actual object being referenced.
            // B) A Deep Copy creates a completely independent copy of the object, including copies of the objects referenced by its reference-type members.
            // C) The reference itself is copied, so both the original and copied object point to the same referenced object
            // D) New copies of the referenced objects are created. Therefore, the original and copied objects have separate reference type members
            // E) Deep Copy would be safer when you need to modify a copied object without affecting the original. For example, if you copy a customer's order and want to change the copied order for testing or editing, a Deep Copy ensures that changes to the copy don't accidentally modify the original order.

            //Question 3
            // A)A static field belongs to the class itself, not to a specific object. There is only one shared copy of a static field for the entire class.An instance field belongs to a specific object, so every object has its own separate copy of that field.
            // B) A static method belongs to the class rather than to a specific object. It can be called without creating an object of the class. A static method cannot directly access instance members because instance members belong to a particular object. It can directly access other static members.
            // C) A static constructor is used to initialize static data or perform setup that should happen only once for the class. It is executed automatically once, before the class is first used, and you cannot call it directly.
            // D) A static class is a class that contains only static members and is designed to be used without creating objects. No, you cannot create an object from a static class. It is accessed directly through the class name.

            //Question 4
            // A) An Extension Method is a method that allows you to add new functionality to an existing class or type without modifying its original source code or creating a derived class. It makes the new method appear as if it were already part of that type.
            // B) The this keyword must be used before the first parameter. This tells C# which type the extension method is extending.
            // C) An extension method must be declared inside a static class.
            // D) An extension method cannot directly access the private members of the class it extends. It can only access members that are accessible to it, such as public members.

            //Question 5
            // A) A Partial Class is a class that can be split into multiple files. Even though the code is separated, C# treats all the parts as one class when the program is compiled.
            // B) to organize a large amount of code.
            // C) A Partial Method is a method that can be declared in one part of a partial class and implemented in another part of the same class. It is useful when a developer wants to provide an optional method that can be implemented only when needed.
            // D) If a partial method is allowed to have no implementation, the compiler removes the method declaration and any calls to it during compilation. This means it does not cause an error and has no effect on the final program.


            //Part 02:

            //01
            //Shipment shipment1 = standardShipment;

            //Shipment shipment2 = shipment1;

            //Shipment shipment3 = shipment1.CopyShipment();

            //Console.WriteLine(shipment1 == shipment2);
            //Console.WriteLine(shipment1 == shipment3);

            //02
            //Shipment originalShipment = standardShipment;

            //Shipment copiedShipment = originalShipment.ShallowCopy();

            //Console.WriteLine(originalShipment == copiedShipment);
            //Console.WriteLine(
            //    originalShipment.Destination == copiedShipment.Destination
            //);

            //copiedShipment.Destination.Street = "New Street";

            //Console.WriteLine($"Original Street: {originalShipment.Destination.Street}");
            //Console.WriteLine($"Copied Street  : {copiedShipment.Destination.Street}");

            //03
            //Shipment originalShipment = standardShipment;

            //Shipment copiedShipment = originalShipment.DeepCopy();

            //Console.WriteLine("Before change");
            //Console.WriteLine($"Original: {originalShipment.Destination.city}");
            //Console.WriteLine($"Copied  : {copiedShipment.Destination.city}");

            //copiedShipment.Destination.city = "Giza";

            //Console.WriteLine();

            //Console.WriteLine("After changing copied address");
            //Console.WriteLine($"Original: {originalShipment.Destination.city}");
            //Console.WriteLine($"Copied  : {copiedShipment.Destination.city}");

            //Console.WriteLine();

            //Console.WriteLine($"Same DeliveryAddress object? {originalShipment.Destination == copiedShipment.Destination}");

            Driver driver = new Driver(1,"Ahmed Ali", "01012345678");

            string centerName;
            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSystemTitle();
            DeliveryUtilities.PrintSeparator();

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


            Console.WriteLine($"Total Shipments Created: {Shipment.TotalShipmentsCreated}");
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
        }

    }

    }
