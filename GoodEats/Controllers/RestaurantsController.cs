using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RestaurantsController : ControllerBase
  {
    private readonly RestaurantsService _rs;
    private readonly ReviewsService _revs;

    public RestaurantsController(RestaurantsService rs, ReviewsService revs)
    {
      _rs = rs;
      _revs = revs;
    }

    [HttpGet]
    public ActionResult<List<Restaurant>> Get()
    {
      try
      {
        List<Restaurant> restaurants = _rs.Get();
        return Ok(restaurants);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Restaurant> Get(int id)
    {
      try
      {
        Restaurant restaurant = _rs.Get(id);
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<List<Review>> GetReviews(int id)
    {
      try
      {
        List<Review> reviews = _revs.GetByRestaurantId(id);
        return Ok(reviews);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Restaurant> Create([FromBody] Restaurant restaurantData)
    {
      try
      {
        Restaurant restaurant = _rs.Create(restaurantData);
        restaurant.CreatedAt = DateTime.UtcNow;
        restaurant.UpdatedAt = DateTime.UtcNow;
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Restaurant> Edit([FromBody] Restaurant restaurantData, int id)
    {
      try
      {
        restaurantData.Id = id;
        Restaurant restaurant = _rs.Edit(restaurantData);
        return Ok(restaurant);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Restaurant> Delete(int id)
    {
      try
      {
        _rs.Delete(id);
        return Ok("Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}