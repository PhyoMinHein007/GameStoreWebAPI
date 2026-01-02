using GameStore.API.Data;
using Microsoft.EntityFrameworkCore;
public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("genres").WithParameterValidation();

    group.MapGet("/", async (GameStoreContext dbContext) =>
    {
      return await dbContext.Genres
      .Select(genre => genre.ToGenreDto())
      .AsNoTracking()
      .ToListAsync();
    });

    return group;
  }
}
