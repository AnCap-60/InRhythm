namespace InRhythmServer.Models;

public abstract class AlbumBase
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public List<Track> Tracks { get; set; }
}