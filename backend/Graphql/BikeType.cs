using backend.Models;
using GraphQL.Types;

namespace backend.Graphql;
public class BikeType : ObjectGraphType<Bike>
    {
        public BikeType()
        {
            Name = "Bike";
            Description = "Bike Type";
            Field(p => p.Android);
            Field(p => p.BikeId);
            Field(p => p.Ios);
            Field(p => p.Lat);
            Field(p => p.Lon);
            Field(p => p.TotalBookings);
            Field(p => p.IsDisabled, nullable: true);
            Field(p => p.IsReserved, nullable: true);
            Field(p => p.VehicleType, nullable: true);
        }
    }