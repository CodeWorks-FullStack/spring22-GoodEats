using GoodEats.Repositories;

namespace GoodEats.Services
{
  public class RestaurantsService
  {
    private readonly RestaurantsRepository _repo;

    public RestaurantsService(RestaurantsRepository repo)
    {
      _repo = repo;
    }
  }
}