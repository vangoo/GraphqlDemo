using Newtonsoft.Json.Linq;

namespace backend.Graphql;

public class GraphqlQueryParameter
{
    public string? Field { get; set; }
    public string? Value { get; set; }
    public string? Query { get; set; }
    public JObject? Variables { get; set; }

}