using System;
using GoodEats.Interfaces;

namespace GoodEats.Models
{
  public class Restaurant : IRepoItem<int>
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public double AverageReview { get; set; }
    public int TotalReviews { get; set; }
  }
}