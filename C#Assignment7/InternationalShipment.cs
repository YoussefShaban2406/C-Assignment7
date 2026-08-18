using C_Assignment7;
using C_Assignment06;

public class InternationalShipment : Shipment, ITrackable, IInsurable
{
    private string destinationCountry;
    private decimal customsFee;

    public string DestinationCountry
    {
        get { return destinationCountry; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                destinationCountry = value;
            }
        }
    }

    public decimal CustomsFee
    {
        get { return customsFee; }
        set
        {
            if (value >= 0)
            {
                customsFee = value;
            }
        }
    }

    public InternationalShipment(
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
            destination)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFeeProperty
                   + (WeightProperty * 5)
                   + CustomsFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("----- International Shipment -----");
        Console.WriteLine($"Tracking Code      : {TrackingCodeProperty}");
        Console.WriteLine($"Description        : {DescriptionProperty}");
        Console.WriteLine($"Weight             : {WeightProperty}");
        Console.WriteLine($"Delivery Fee       : {DeliveryFeeProperty}");
        Console.WriteLine($"Destination        : {Destination.GetFullAddress()}");
        Console.WriteLine($"Estimated Cost     : {EstimatedCost}");
        Console.WriteLine($"Destination Country: {DestinationCountry}");
        Console.WriteLine($"Customs Fee        : {CustomsFee}");
        Console.WriteLine($"Insurance          : {CalculateInsurance()}");
        Console.WriteLine("-----------------------------------");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCodeProperty} has been Delivered.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.12m;
    }

    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine("----- Customs Report -----");
        Console.WriteLine($"Destination Country: {DestinationCountry}");
        Console.WriteLine($"Customs Fee        : {CustomsFee}");
        Console.WriteLine("--------------------------");
    }
}