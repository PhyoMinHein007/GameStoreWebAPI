using GameStore.API.Dtos;
using GameStore.API.Entities;

public static class GenreMapping
{
  public static GenreDto ToGenreDto(this Genre genre)
  {
    return new GenreDto(
        genre.Id,
        genre.Name
      );
  }

  
}