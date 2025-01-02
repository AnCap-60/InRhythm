namespace InRhythmServer.Models;

public class Album : AlbumBase
{
    public IEnumerable<Tag> Tags { get; set; }
}