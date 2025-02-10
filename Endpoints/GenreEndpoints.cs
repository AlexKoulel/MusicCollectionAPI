using Microsoft.EntityFrameworkCore;
using MusicCollectionAPI.Data;
using MusicCollectionAPI.DTOs.GenreDTOs;
using MusicCollectionAPI.Entities;
using MusicCollectionAPI.Mapping;

namespace MusicCollectionAPI.Endpoints
{
    public static class GenreEndpoints
    {
        const string GetGenreEndpointName = "GetGenre";

        public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (MusicCollectionContext dbContext) =>
                await dbContext.Genres
                               .Select(genre => genre.ToDTO())
                               .AsNoTracking()
                               .ToListAsync());

            //GET /genres/id
            group.MapGet("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                Genre? genre = await dbContext.Genres.FindAsync(id);

                return genre is null ?
                        Results.NotFound() : Results.Ok(genre.ToDTO());
            }).WithName(GetGenreEndpointName);

            //POST /genres
            group.MapPost("/", async (CreateGenreDTO newGenre, MusicCollectionContext dbContext) =>
            {
                try
                {
                    if (newGenre == null)
                    {
                        return Results.BadRequest("Invalid Genre data.");
                    }
                    Genre genre = newGenre.GenreToEntity();
                    dbContext.Genres.Add(genre);
                    await dbContext.SaveChangesAsync();
                    return Results.Ok("Success");
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error occured.{ex}");
                }

            });

            //PUT /genres
            group.MapPut("/{id}", async (int id, UpdateGenreDTO updatedGenre, MusicCollectionContext dbContext) =>
            {
                var existingGenre = await dbContext.Genres.FindAsync(id);

                if (existingGenre is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGenre)
                         .CurrentValues
                         .SetValues(updatedGenre.GenreToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            //DELETE /genres/1
            group.MapDelete("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                await dbContext.Genres
                               .Where(genre => genre.Id == id)
                               .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
