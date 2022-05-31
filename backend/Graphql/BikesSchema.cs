using GraphQL.Types;

namespace backend.Graphql;

public class BikesSchema : Schema
{
    public BikesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<BikesQuery>();
    }
}