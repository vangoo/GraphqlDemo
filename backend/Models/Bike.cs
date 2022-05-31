
using backend.Enums;

namespace backend.Models;



public class Bike
{
    private readonly string _androidUrl = "https://deeplink.helbiz.com/startRide?code=";

    private readonly string _iosUrl = "https://deeplink.helbiz.com/startRide?code=";

    public string? BikeId { get; set; }

    public string Ios 
    {
        get
        {
            return _iosUrl + BikeId;
        }
    }

    public string Android
    {
        get
        {
            return _androidUrl + BikeId;
        }
    }

    public bool IsDisabled { get; set; }

    public bool IsReserved { get; set; }

    public double Lat { get; set; }

    public double Lon { get; set; }

    public int TotalBookings { get; set; }

    public VehicleType VehicleType { get; set; }
}