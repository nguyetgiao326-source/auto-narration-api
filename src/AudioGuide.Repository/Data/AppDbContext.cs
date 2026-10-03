using AudioGuide.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioGuide.Repository.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Narration> Narrations => Set<Narration>();
    public DbSet<AudioFile> AudioFiles => Set<AudioFile>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Language>().HasIndex(x => x.Code).IsUnique();
        b.Entity<Location>().HasIndex(x => x.QrCode).IsUnique();
        b.Entity<User>().HasIndex(x => x.Username).IsUnique();
        b.Entity<User>().Property(x => x.Role).HasConversion<string>();

        // Mỗi điểm chỉ có 1 bản thuyết minh cho mỗi ngôn ngữ
        b.Entity<Narration>()
            .HasIndex(x => new { x.LocationId, x.LanguageId }).IsUnique();

        // 1 Narration có tối đa 1 AudioFile
        b.Entity<Narration>()
            .HasOne(x => x.AudioFile)
            .WithOne(x => x.Narration)
            .HasForeignKey<AudioFile>(x => x.NarrationId);
    }
}