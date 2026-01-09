using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
  private readonly List<GameSummary> games = new ()
  {
    new GameSummary { Id = 1, Name = "Mobile Legends", Genre = "Moba", Price = 29.99m, ReleaseDate = new DateOnly(2022, 5, 15) },
    new GameSummary { Id = 2, Name = "Racing Pro", Genre = "Racing", Price = 49.99m, ReleaseDate = new DateOnly(2021, 11, 20) },
    new GameSummary { Id = 3, Name = "Puzzle Master", Genre = "Puzzle", Price = 19.99m, ReleaseDate = new DateOnly(2023, 2, 10) }
  };

  private readonly Genre[] genres = new GenresClient().GetAllGenres();

  public GameSummary[] GetAllGames() => [..games];

  public void AddGame(GameDetails newGame)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(newGame.GenreId);
    var gameSummary = new GameSummary
    {
      Id = games.Count + 1,
      Name = newGame.Name,
      Genre = genres.FirstOrDefault(g => g.Id == int.Parse(newGame.GenreId))?.Name ?? "Unknown",
      Price = newGame.Price,
      ReleaseDate = newGame.ReleaseDate
    };

    games.Add(gameSummary);   
  }
}
