namespace GameStore.API.Dtos;

using System.ComponentModel.DataAnnotations;


public record class UpdateGameDto(
  [Required][StringLength(50)] string Name,
  int GenreId,
  [Range(1, 10000)] decimal Price,
  DateOnly ReleaseDate
);
