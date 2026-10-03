namespace AudioGuide.Model.Entities;

public class AudioFile
{
    public int Id { get; set; }
    public int NarrationId { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public int DurationSeconds { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Narration Narration { get; set; } = null!;
}