using MusicCollectionAPI.Data;
using MusicCollectionAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MusicCollectionDB");
builder.Services.AddSqlite<MusicCollectionContext>(connectionString);


var app = builder.Build();
app.MapAlbumsEndpoints();
app.MapGenreEndpoints();
app.MapFormatEndpoints();
await app.MigrateDbAsync();
app.Run();
