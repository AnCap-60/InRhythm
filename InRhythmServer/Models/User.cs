namespace InRhythmServer.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string PasswordHash { get; set; }
    
    public IEnumerable<Track> SavedTracks { get; set; }
}