using C_Assignment06;
using C_Assignment7;

public class StandardShipment : Shipment, ITrackable, IInsurable
{
    public StandardShipment(
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
        Console.WriteLine("----- Standard Shipment -----");
        Console.WriteLine($"Tracking Code : {TrackingCodeProperty}");
        Console.WriteLine($"Description   : {DescriptionProperty}");
        Console.WriteLine($"Weight        : {WeightProperty}");
        Console.WriteLine($"Delivery Fee  : {DeliveryFeeProperty}");
        Console.WriteLine($"Destination   : {Destination.GetFullAddress()}");
        Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        Console.WriteLine($"Insurance     : {CalculateInsurance()}");
        Console.WriteLine("-----------------------------");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCodeProperty} is Ready.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }
}