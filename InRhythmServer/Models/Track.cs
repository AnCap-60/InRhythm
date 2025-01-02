namespace InRhythmServer.Models;

public class Track
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public int DurationSeconds { get; set; }
    
    public AlbumBase? Album { get; set; }
    
    public IEnumerable<Tag> Tags { get; set; }
}