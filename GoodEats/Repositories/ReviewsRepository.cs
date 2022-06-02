using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class ReviewsRepository
  {
    private readonly IDbConnection _db;

    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Review> GetByCreatorId(string id)
    {
      string sql = @"
      SELECT 
       r.*,
       a.*
      FROM reviews r
      JOIN accounts a ON r.creatorId = a.id 
      WHERE creatorId = @id";
      return _db.Query<Review, Profile, Review>(sql, (r, p) =>
      {
        r.Creator = p;
        return r;
      }, new { id }).ToList();
    }

    internal List<Review> GetByRestaurantId(int id)
    {
      string sql = @"
        SELECT
            rv.*,
            a.*
        FROM reviews rv
        JOIN accounts a ON rv.creatorId = a.id
        WHERE rv.restaurantId = @id;";
      return _db.Query<Review, Profile, Review>(sql, (rv, p) =>
      {
        rv.Creator = p;
        return rv;
      }, new { id }).ToList();
    }

    internal Review Get(int id)
    {
      string sql = @"
        SELECT
            rv.*,
            a.*
        FROM reviews rv
        JOIN accounts a ON rv.creatorId = a.id
        WHERE rv.id = @id;";
      return _db.Query<Review, Profile, Review>(sql, (rv, p) =>
      {
        rv.Creator = p;
        return rv;
      }, new { id }).FirstOrDefault();
    }

    internal Review Create(Review reviewData)
    {
      string sql = @"
        INSERT INTO reviews
        (rating, comment, restaurantId, creatorId)
        VALUES
        (@Rating, @Comment, @RestaurantId, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
      reviewData.Id = _db.ExecuteScalar<int>(sql, reviewData);
      return reviewData;
    }

    internal void Edit(Review original)
    {
      string sql = @"
      UPDATE reviews
      SET
        rating = @Rating,
        comment = @Comment
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM reviews WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}