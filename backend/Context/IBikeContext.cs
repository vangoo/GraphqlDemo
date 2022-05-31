using backend.Models;

namespace backend.Context;

public interface IBikeContext
{
    IList<Bike> GetAll();
}