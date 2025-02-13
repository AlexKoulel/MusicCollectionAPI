using Microsoft.EntityFrameworkCore;

namespace MusicCollectionAPI.Backend.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MusicCollectionContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
