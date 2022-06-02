using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _acctService;
    public ProfilesController(AccountService acctService)
    {
      _acctService = acctService;
    }
  }
}