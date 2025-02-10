using Microsoft.EntityFrameworkCore;
using MusicCollectionAPI.Data;
using MusicCollectionAPI.DTOs.AlbumDTOs;
using MusicCollectionAPI.Entities;
using MusicCollectionAPI.Mapping;

namespace MusicCollectionAPI.Endpoints
{
    public static class AlbumEnpoints
    {
        const string GetAlbumEnpointName = "GetAlbum";

        public static RouteGroupBuilder MapAlbumsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("albums").WithParameterValidation();

            //GET /albums
            group.MapGet("/", async (MusicCollectionContext dbContext) =>
                await dbContext.Albums
                               .Include(album => album.Genre)
                               .Include(album => album.Format)
                               .Select(album => album.ToAlbumSummaryDTO())
                               .AsNoTracking()
                               .ToListAsync());

            //GET /albums/id
            group.MapGet("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                Album? album = await dbContext.Albums.FindAsync(id);

                return album is null ?
                        Results.NotFound() : Results.Ok(album.ToAlbumDetailsDTO());
            }).WithName(GetAlbumEnpointName);

            //POST /albums
            group.MapPost("/", async (CreateAlbumDTO newAlbum, MusicCollectionContext dbContext) =>
            {
                try
                {
                    if (newAlbum == null)
                    {
                        return Results.BadRequest("Invalid Album data.");
                    }
                    Album album = newAlbum.AlbumToEntity();
                    dbContext.Albums.Add(album);
                    await dbContext.SaveChangesAsync();
                    return Results.Ok("Success");
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error occured.{ex}");
                }

            });

            //PUT /albums
            group.MapPut("/{id}", async(int id, UpdateAlbumDTO updatedAlbum, MusicCollectionContext  dbContext) =>
            {
                var existingAlbum = await dbContext.Albums.FindAsync(id);

                if (existingAlbum is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingAlbum)
                         .CurrentValues
                         .SetValues(updatedAlbum.AlbumToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            //DELETE /albums/1
            group.MapDelete("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                await dbContext.Albums
                               .Where(album => album.Id == id)
                               .ExecuteDeleteAsync();

                return Results.NoContent();
            });


            return group;
        }
    }
}
