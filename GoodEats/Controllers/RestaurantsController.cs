using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RestaurantsController : ControllerBase
  {
    private readonly RestaurantsService _rs;

    public RestaurantsController(RestaurantsService rs)
    {
      _rs = rs;
    }
  }
}