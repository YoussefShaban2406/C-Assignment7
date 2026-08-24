using C_Assignment7;
using C_Assignment06;

public class ExpressShipment : Shipment, ITrackable, IInsurable
{
    private decimal extraFee;

    public decimal ExtraFee
    {
        get { return extraFee; }
        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
        }
    }

    public ExpressShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        decimal extraFee)
        : base(
            trackingCode,
            description,
            weight,
            deliveryFee,
            destination)
    {
        ExtraFee = extraFee;
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFeeProperty
                   + (WeightProperty * 5)
                   + ExtraFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("----- Express Shipment -----");
        Console.WriteLine($"Tracking Code : {TrackingCodeProperty}");
        Console.WriteLine($"Description   : {DescriptionProperty}");
        Console.WriteLine($"Weight        : {WeightProperty}");
        Console.WriteLine($"Delivery Fee  : {DeliveryFeeProperty}");
        Console.WriteLine($"Destination   : {Destination.GetFullAddress()}");
        Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        Console.WriteLine($"Extra Fee     : {ExtraFee}");
        Console.WriteLine($"Insurance     : {CalculateInsurance()}");
        Console.WriteLine("----------------------------");
    }

    public override string GetTrackingStatus()
    {
        return $"Shipment {TrackingCodeProperty} is Out for Delivery.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m;
    }
}