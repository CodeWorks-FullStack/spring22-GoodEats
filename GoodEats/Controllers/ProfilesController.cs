using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _acctService;
    private readonly ReviewsService _rs;

    public ProfilesController(AccountService acctService, ReviewsService rs)
    {
      _acctService = acctService;
      _rs = rs;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        // FIXME this isn't casting right
        Profile profile = _acctService.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<List<Review>> GetReviews(string id)
    {
      try
      {
        _acctService.GetProfileById(id);
        List<Review> reviews = _rs.GetByCreatorId(id);
        return Ok(reviews);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}