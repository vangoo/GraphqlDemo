using backend.Enums;
using backend.Models;

namespace backend.Context;

public class BikeContext : IBikeContext
{
    private readonly List<Bike> _bikes = new List<Bike>();

    public BikeContext()
    {

        _bikes.Add(new Bike
        {
            BikeId = "OS7VA",
            Lat = 39.9244125486328,
            Lon = 32.8643810105882,
            TotalBookings = 8,
            IsDisabled = true,
            IsReserved = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "Q2RLQ",
            Lat = 39.92575291543032,
            Lon = 32.8684158583946,
            TotalBookings = 12,
            VehicleType = VehicleType.Scooter
        });

        _bikes.Add(new Bike
        {
            BikeId = "Z2LBF",
            Lat = 39.92650444469358,
            Lon = 32.868612121137396,
            TotalBookings = 12,
            VehicleType = VehicleType.Scooter
        });

        _bikes.Add(new Bike
        {
            BikeId = "INZPG",
            Lat = 39.92533846870144,
            Lon = 32.86444171725884,
            TotalBookings = 5,
            VehicleType = VehicleType.Bike
        });

        _bikes.Add(new Bike
        {
            BikeId = "FBGXO",
            Lat = 39.92628897743294,
            Lon = 32.86483471634385,
            TotalBookings = 2,
            VehicleType = VehicleType.Bike
        });

        _bikes.Add(new Bike
        {
            BikeId = "LT3RT",
            Lat = 39.9245743946225,
            Lon = 32.86590391032198,
            TotalBookings = 0,
            VehicleType = VehicleType.Bike,
            IsDisabled = true,
            IsReserved = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "T2ZX9",
            Lat = 39.92560503037201,
            Lon = 32.866299055506886,
            TotalBookings = 5,
            VehicleType = VehicleType.Scooter,
            IsDisabled = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "2NP1R",
            Lat = 39.925381504646495,
            Lon = 32.86349704014174,
            TotalBookings = 7,
            VehicleType = VehicleType.Scooter
        });

        _bikes.Add(new Bike
        {
            BikeId = "WZKOU",
            Lat = 39.92647916258679,
            Lon = 32.86543575881174,
            TotalBookings = 2,
            IsReserved = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "FV2FO",
            Lat = 39.92631783185765,
            Lon = 32.86544307082304,
            TotalBookings = 7,
            IsDisabled = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "CGL8T",
            Lat = 39.9259013070281,
            Lon = 32.8669404346796,
            TotalBookings = 4,
            VehicleType = VehicleType.Scooter,
            IsDisabled = true,
            IsReserved = true
        });

        _bikes.Add(new Bike
        {
            BikeId = "E0IRF",
            Lat = 39.925681354797405,
            Lon = 32.86580173340848,
            TotalBookings = 9,
            VehicleType = VehicleType.Bike,
            IsDisabled = true
        });
    }

    public IList<Bike> GetAll() => _bikes;
}