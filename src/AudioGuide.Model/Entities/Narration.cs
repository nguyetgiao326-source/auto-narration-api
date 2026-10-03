namespace AudioGuide.Model.Entities;

public class Narration
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public int LanguageId { get; set; }
    public string Content { get; set; } = string.Empty; // bản thuyết minh đã dịch
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Location Location { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public AudioFile? AudioFile { get; set; }
}