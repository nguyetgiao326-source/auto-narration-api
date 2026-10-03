using AudioGuide.Model.Dtos;
using AudioGuide.Model.Entities;
using AudioGuide.Repository.Repositories;

namespace AudioGuide.Service;

public class LocationService : ILocationService
{
    private readonly IRepository<Location> _repo;

    public LocationService(IRepository<Location> repo)
    {
        _repo = repo;
    }

    public async Task<List<LocationDto>> GetAllAsync()
    {
        var all = await _repo.GetAllAsync();
        return all.OrderBy(l => l.Id).Select(ToDto).ToList();
    }

    public async Task<LocationDto?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        return entity is null ? null : ToDto(entity);
    }

    public async Task<LocationDto> CreateAsync(SaveLocationRequest request)
    {
        var entity = new Location
        {
            Name = request.Name,
            Description = request.Description,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            QrCode = Guid.NewGuid().ToString("N")[..8]
        };

        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task<LocationDto?> UpdateAsync(int id, SaveLocationRequest request)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null) return null;

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Latitude = request.Latitude;
        entity.Longitude = request.Longitude;

        _repo.Update(entity);
        await _repo.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null) return false;

        _repo.Remove(entity);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static LocationDto ToDto(Location l) =>
        new(l.Id, l.Name, l.Description, l.Latitude, l.Longitude, l.QrCode);
}