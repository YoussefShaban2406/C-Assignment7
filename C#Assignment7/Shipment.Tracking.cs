using System;
using System.Collections.Generic;
using System.Text;

public abstract partial class Shipment
{
    
    private string trackingStatus = "Ready";

    public void UpdateTrackingStatus(string newStatus)
    {
        if (!string.IsNullOrWhiteSpace(newStatus))
        {
            trackingStatus = newStatus;
        }
    }
}
