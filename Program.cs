using Microsoft.EntityFrameworkCore;
using MusicCollectionAPI.Backend.Data;
using MusicCollectionAPI.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MusicCollectionDB");
builder.Services.AddDbContext<MusicCollectionContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
            policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
});

var app = builder.Build();
app.UseCors("AllowAll");
app.MapAlbumsEndpoints();
app.MapGenreEndpoints();
app.MapFormatEndpoints();
await app.MigrateDbAsync();
app.Run();
