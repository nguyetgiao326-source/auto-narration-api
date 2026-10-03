using System.ComponentModel.DataAnnotations;

namespace AudioGuide.Model.Dtos;

public class SaveLocationRequest
{
    [Required, StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(-90, 90)]
    public double Latitude { get; set; }

    [Range(-180, 180)]
    public double Longitude { get; set; }
}