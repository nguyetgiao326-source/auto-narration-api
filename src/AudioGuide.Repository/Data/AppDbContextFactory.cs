using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AudioGuide.Repository.Data;

// Chỉ dùng cho lệnh "dotnet ef" khi phát triển
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=audioguide;Username=audioguide;Password=audioguide123")
            .Options;
        return new AppDbContext(options);
    }
}