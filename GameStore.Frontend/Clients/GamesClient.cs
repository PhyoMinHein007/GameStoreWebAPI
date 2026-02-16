using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
  private readonly List<GameSummary> games = new ()
  {
    new GameSummary { Id = 1, Name = "Mobile Legends", Genre = "Moba", Price = 29.99m, ReleaseDate = new DateOnly(2022, 5, 15) },
    new GameSummary { Id = 2, Name = "Racing Pro", Genre = "Racing", Price = 49.99m, ReleaseDate = new DateOnly(2021, 11, 20) },
    new GameSummary { Id = 3, Name = "Puzzle Master", Genre = "Puzzle", Price = 19.99m, ReleaseDate = new DateOnly(2023, 2, 10) }
  };

  private readonly Genre[] genres = new GenresClient(httpClient).GetAllGenres();

  public GameSummary[] GetAllGames() => [..games];

  public void AddGame(GameDetails newGame)
  {
    Genre? genre = GetGenreById(newGame.GenreId);
    var gameSummary = new GameSummary
    {
      Id = games.Count + 1,
      Name = newGame.Name,
      Genre = genre?.Name ?? "Unknown",
      Price = newGame.Price,
      ReleaseDate = newGame.ReleaseDate
    };

    games.Add(gameSummary);
  }

  public void UpdateGame(GameDetails updatedGame)
  {
    var genre = GetGenreById(updatedGame.GenreId);
    var existingGame = GetGameSummaryById(updatedGame.Id);

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = genre?.Name ?? "Unknown";
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
  }

  

  public GameDetails GetGameDetails(int id)
  {
    GameSummary gameSummary = GetGameSummaryById(id);

    var genre = genres.FirstOrDefault(d => string.Equals(d.Name, gameSummary.Genre, StringComparison.OrdinalIgnoreCase));

    return new GameDetails
    {
      Id = gameSummary.Id,
      Name = gameSummary.Name,
      GenreId = genre?.Id.ToString(),
      Price = gameSummary.Price,
      ReleaseDate = gameSummary.ReleaseDate
    };
  }

  private Genre? GetGenreById(string? id)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(id);
    var genre = genres.FirstOrDefault(g => g.Id == int.Parse(id));
    return genre;
  }

  private GameSummary GetGameSummaryById(int id)
  {
    GameSummary? gameSummary = games?.FirstOrDefault(g => g.Id == id);
    ArgumentNullException.ThrowIfNull(gameSummary);
    return gameSummary;
  }

  public void DeleteGame(int id)
  {
    var gameSummary = GetGameSummaryById(id);
    games.Remove(gameSummary);
  }
}
