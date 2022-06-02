using System;
using System.Collections.Generic;
using GoodEats.Models;
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
    internal List<Restaurant> Get()
    {
      return _repo.Get();
    }

    internal Restaurant Create(Restaurant restaurantData)
    {
      return _repo.Create(restaurantData);
    }

    internal Restaurant Get(int id)
    {
      Restaurant found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Restaurant Edit(Restaurant restaurantData)
    {
      Restaurant original = Get(restaurantData.Id);
      original.Name = restaurantData.Name ?? original.Name;
      original.Image = restaurantData.Image ?? original.Image;
      original.Address = restaurantData.Address ?? original.Address;
      original.UpdatedAt = DateTime.UtcNow;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }
  }
}