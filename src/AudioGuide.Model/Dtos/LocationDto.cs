namespace AudioGuide.Model.Dtos;

public record LocationDto(
    int Id,
    string Name,
    string Description,
    double Latitude,
    double Longitude,
    string QrCode);