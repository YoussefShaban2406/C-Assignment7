using C_Assignment06;

public abstract partial class Shipment
{
    private string TrackingCode;
    private string Description;
    private decimal Weight;
    private decimal DeliveryFee;

    public static int TotalShipmentsCreated = 0;


    static Shipment()
    {
        TotalShipmentsCreated = 0;
        Console.WriteLine("Shipment System Initialized");
    }

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

        TotalShipmentsCreated++;
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

        TotalShipmentsCreated++;
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

    public Shipment CopyShipment()
    {
        return (Shipment)this.MemberwiseClone();
    }
    public Shipment ShallowCopy()
    {
        return (Shipment)this.MemberwiseClone();
    }

    public Shipment DeepCopy()
    {
        Shipment copy = (Shipment)this.MemberwiseClone();

        copy.Destination = new DeliveryAddress(
            this.Destination.city,
            this.Destination.Street,
            this.Destination.BuildingNumber
        );

        return copy;
    }

    public static int GetTotalShipmentsCreated()
    {
        return TotalShipmentsCreated;
    }


    public abstract string GetTrackingStatus();
}
