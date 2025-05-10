using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Models;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Tag> Tags { get; set; }
     
    public DbSet<Track> Tracks { get; set; }
     
    public DbSet<Album> Albums { get; set; }
     
    public DbSet<Artist> Artists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}