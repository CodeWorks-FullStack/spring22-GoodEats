using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _rs;

    public ReviewsController(ReviewsService rs)
    {
      _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Review>> Create([FromBody] Review reviewData)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        reviewData.CreatorId = userInfo.Id;
        Review review = _rs.Create(reviewData);
        review.CreatedAt = DateTime.UtcNow;
        review.UpdatedAt = DateTime.UtcNow;
        review.Creator = userInfo;
        return Ok(review);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Review>> Edit([FromBody] Review updateData, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updateData.CreatorId = userInfo.Id;
        updateData.Id = id;
        Review updated = _rs.Edit(updateData);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> Remove(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _rs.Remove(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}