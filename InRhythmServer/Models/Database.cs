using Microsoft.EntityFrameworkCore;

namespace InRhythmServer.Models;

public class Database : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Tag> Tags { get; set; }
     
    public DbSet<Track> Tracks { get; set; }
     
    public DbSet<AlbumBase> Albums { get; set; }
     
    public DbSet<Artist> Artists { get; set; }
}