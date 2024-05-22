using Microsoft.EntityFrameworkCore;

namespace Application.Shared.Infraestructure.Context;

public class ArtCollabDbContext(DbContextOptions<ArtCollabDbContext> options) : DbContext(options)
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("Error with database configuration");
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}