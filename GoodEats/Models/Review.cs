using System;
using GoodEats.Interfaces;

namespace GoodEats.Models
{
  public class Review : IRepoItem<int>
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public int RestaurantId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Profile Creator { get; set; }
  }
}