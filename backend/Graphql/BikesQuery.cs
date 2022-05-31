using backend.Context;
using backend.Enums;
using backend.Models;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;

namespace backend.Graphql;

public class BikesQuery : ObjectGraphType
{
    private readonly IBikeContext _Context;

    public BikesQuery(IBikeContext _context)
    {
        _Context = _context;

        Field<ListGraphType<BikeType>>(
            "bikes",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "id" },
                new QueryArgument<StringGraphType> { Name = "type" }
            ),
            resolve: context =>
            {
                var _data = _context.GetAll();

                if (context.Arguments == null)
                {

                    return _data;
                }

                var _id = context.GetArgument<string>("id");

                if (!string.IsNullOrEmpty(_id))
                {
                    _data = _data.
                    Where(x => !string.IsNullOrEmpty(x.BikeId) && x.BikeId.ToUpper().Contains(_id.ToUpper())).
                    ToList();
                }

                var _type = context.GetArgument<string>("type");

                if (!string.IsNullOrEmpty(_type))
                {
                    if (VehicleType.Bike.ToString().Equals(_type))
                    {
                        _data = _data.Where(x => x.VehicleType == VehicleType.Bike).ToList();
                    }
                    else if (VehicleType.Scooter.ToString().Equals(_type))
                    {
                        _data = _data.Where(x => x.VehicleType == VehicleType.Scooter).ToList();
                    }
                }

                return _data;

            }
        );

        Field<BikeType>(
            "bikeById",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                if (context.Arguments == null)
                {
                    return null;
                }

                var _id = context.GetArgument<string>("id");

                return _context.GetAll().FirstOrDefault(x => !string.IsNullOrEmpty(x.BikeId) && x.BikeId.Equals(_id));

            }
        );
    }
}