using Microsoft.EntityFrameworkCore;
using MusicCollectionAPI.Backend.Data;
using MusicCollectionAPI.Backend.DTOs.FormatDTOs;
using MusicCollectionAPI.Backend.Entities;
using MusicCollectionAPI.Backend.Mapping;

namespace MusicCollectionAPI.Backend.Endpoints
{
    public static class FormatEndpoints
    {
        const string GetFormatEndpoint = "GetFormat";
        public static RouteGroupBuilder MapFormatEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("formats").WithParameterValidation();

            //GET /formats
            group.MapGet("/", async (MusicCollectionContext dbContext) =>
                await dbContext.Formats
                               .Select(format => format.ToDTO())
                               .AsNoTracking()
                               .ToListAsync()
             );

            //GET /formats/id
            group.MapGet("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                Format? format = await dbContext.Formats.FindAsync(id);

                return format is null ?
                        Results.NotFound() : Results.Ok(format.ToDTO());
            }).WithName(GetFormatEndpoint);

            //POST /formats
            group.MapPost("/", async (CreateFormatDTO newFormat, MusicCollectionContext dbContext) =>
            {
                try
                {
                    if (newFormat == null)
                    {
                        return Results.BadRequest("Invalid Format data.");
                    }
                    Format format = newFormat.FormatToEntity();
                    dbContext.Formats.Add(format);
                    await dbContext.SaveChangesAsync();
                    return Results.Ok("Success");
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error occured.{ex}");
                }

            });

            //PUT /formats
            group.MapPut("/{id}", async (int id, UpdateFormatDTO updatedFormat, MusicCollectionContext dbContext) =>
            {
                var existingFormat = await dbContext.Formats.FindAsync(id);

                if (existingFormat is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingFormat)
                         .CurrentValues
                         .SetValues(updatedFormat.FormatToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            //DELETE /formats/1
            group.MapDelete("/{id}", async (int id, MusicCollectionContext dbContext) =>
            {
                await dbContext.Formats
                               .Where(format => format.Id == id)
                               .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
