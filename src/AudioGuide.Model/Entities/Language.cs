namespace AudioGuide.Model.Entities;

public class Language
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;   // vi, en, ja, ko...
    public string Name { get; set; } = string.Empty;   // Tiếng Việt, English...
    public bool IsActive { get; set; } = true;

    public List<Narration> Narrations { get; set; } = new();
}