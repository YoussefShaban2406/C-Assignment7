using C_Assignment06;

public abstract class Shipment
{
    private string TrackingCode;
    private string Description;
    private decimal Weight;
    private decimal DeliveryFee;

    public Shipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination)
    {
        TrackingCode = "";
        Description = "";
        Weight = 0;
        DeliveryFee = 0;
        Destination = destination;

        TrackingCodeProperty = trackingCode;
        DescriptionProperty = description;
        WeightProperty = weight;
        DeliveryFeeProperty = deliveryFee;
    }

    public Shipment(string trackingCode)
    {
        TrackingCode = "";
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;

        Destination = new DeliveryAddress(
            "Unknown",
            "Unknown",
            0
        );

        TrackingCodeProperty = trackingCode;

        if (string.IsNullOrWhiteSpace(TrackingCode))
        {
            TrackingCode = "Unknown";
        }
    }

    public string TrackingCodeProperty
    {
        get { return TrackingCode; }
        private set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                TrackingCode = value;
            }
        }
    }

    public string DescriptionProperty
    {
        get { return Description; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Description = value;
            }
        }
    }

    public decimal WeightProperty
    {
        get { return Weight; }
        set
        {
            if (value > 0)
            {
                Weight = value;
            }
        }
    }

    public decimal DeliveryFeeProperty
    {
        get { return DeliveryFee; }
        private set
        {
            if (value > 0)
            {
                DeliveryFee = value;
            }
        }
    }

    public DeliveryAddress Destination { get; set; }

    public abstract decimal EstimatedCost { get; }

    public abstract void PrintShipment();

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            DeliveryFee = newFee;
        }
    }

    public void UpdateWeight(decimal newWeight)
    {
        if (newWeight > 0)
        {
            WeightProperty = newWeight;
        }
    }

    public void UpdateWeight(
        decimal newWeight,
        decimal extraPackingWeight)
    {
        if (newWeight > 0 && extraPackingWeight >= 0)
        {
            WeightProperty = newWeight + extraPackingWeight;
        }
    }
}