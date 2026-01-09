using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
  private readonly Genre[] genres = new Genre[]
  {
    new() { Id = 1, Name = "Moba" },
    new() { Id = 2, Name = "Role Playing" },
    new() { Id = 3, Name = "Shooter" },
    new() { Id = 4, Name = "Friends and Family" },
    new() { Id = 5, Name = "Horror" }
  };

  public Genre[] GetAllGenres()
  {
    return genres;
  }
}
  
