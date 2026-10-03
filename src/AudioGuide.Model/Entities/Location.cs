namespace AudioGuide.Model.Entities;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; // nội dung gốc (tiếng Việt)
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string QrCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Narration> Narrations { get; set; } = new();
}