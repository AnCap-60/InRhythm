namespace InRhythmServer.Models;

public class Track
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Url { get; set; }
    
    public int DurationSeconds { get; set; }
    
    public Album? Album { get; set; }
    
    public IEnumerable<Tag> Tags { get; set; }
}