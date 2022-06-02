using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Repositories;

namespace GoodEats.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _repo;

    public ReviewsService(ReviewsRepository repo)
    {
      _repo = repo;
    }

    internal List<Review> GetByCreatorId(string id)
    {
      return _repo.GetByCreatorId(id);
    }

    internal Review Create(Review reviewData)
    {
      return _repo.Create(reviewData);
    }

    internal List<Review> GetByRestaurantId(int id)
    {
      // TODO[epic=Jake] check restaurant;
      return _repo.GetByRestaurantId(id);
    }

    internal void Remove(int id, string userId)
    {
      Review found = Get(id);
      HasOwnership(found.CreatorId, userId);
      _repo.Remove(id);
    }

    private static void HasOwnership(string creatorId, string userId)
    {
      if (creatorId != userId)
      {
        throw new Exception("Invalid Access You Doughnut");
      }
    }

    private Review Get(int id)
    {
      Review found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id You Doughnut");
      }
      return found;
    }

    internal Review Edit(Review updateData)
    {
      Review original = Get(updateData.Id);
      HasOwnership(original.CreatorId, updateData.CreatorId);

      original.Rating = updateData.Rating > 0 ? updateData.Rating : original.Rating;
      original.Comment = updateData.Comment ?? original.Comment;

      _repo.Edit(original);

      return original;
    }
  }
}