namespace InRhythmServer.Models;

public class Album
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public List<Track> Tracks { get; set; }
}