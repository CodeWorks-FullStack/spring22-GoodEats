using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class RestaurantsRepository
  {
    private readonly IDbConnection _db;

    public RestaurantsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Restaurant Create(Restaurant restaurantData)
    {
      string sql = @"
      INSERT INTO restaurants
      (name, address, image)
      VALUES
      (@Name, @Address, @Image);
      SELECT LAST_INSERT_ID();
      ";
      restaurantData.Id = _db.ExecuteScalar<int>(sql, restaurantData);
      return restaurantData;
    }

    internal List<Restaurant> Get()
    {
      string sql = @"
      SELECT
        rs.*,
        AVG(rv.rating) AS AverageRating,
        COUNT(rv.id) AS TotalReviews
      FROM restaurants rs
      LEFT JOIN reviews rv on rv.restaurantId = rs.id
      GROUP BY rs.id;";
      return _db.Query<Restaurant>(sql).ToList();
    }

    internal Restaurant Get(int id)
    {
      string sql = @"
        SELECT
            rs.*,
            AVG(rv.rating) AS AverageRating,
            COUNT(rv.id) AS TotalReviews
        FROM restaurants rs
        LEFT JOIN reviews rv on rv.restaurantId = rs.id
        WHERE rs.id = @id;";
      return _db.QueryFirstOrDefault<Restaurant>(sql, new { id });
    }

    internal void Edit(Restaurant original)
    {
      string sql = @"
        UPDATE restaurants
        SET
            name = @Name,
            address = @Address,
            image = @Image
        WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM restaurants WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}