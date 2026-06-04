using Microsoft.EntityFrameworkCore;
using ShotCaller.Domain;

namespace ShotCaller.Infrastructure.Data;

public class ShotCallerDbContext : DbContext
{
    public ShotCallerDbContext(DbContextOptions<ShotCallerDbContext> options)
        : base(options) { }

    public DbSet<Match> Matches => Set<Match>();
    public DbSet<Prediction> Predictions => Set<Prediction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.HomeTeam).IsRequired().HasMaxLength(100);
            entity.Property(m => m.AwayTeam).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Group).IsRequired().HasMaxLength(20);

            entity.HasMany(m => m.Predictions)
                  .WithOne(p => p.Match)
                  .HasForeignKey(p => p.MatchId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Prediction>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        });
    }
}