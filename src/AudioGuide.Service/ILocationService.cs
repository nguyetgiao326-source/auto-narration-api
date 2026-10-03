using AudioGuide.Model.Dtos;

namespace AudioGuide.Service;

public interface ILocationService
{
    Task<List<LocationDto>> GetAllAsync();
    Task<LocationDto?> GetByIdAsync(int id);
    Task<LocationDto> CreateAsync(SaveLocationRequest request);
    Task<LocationDto?> UpdateAsync(int id, SaveLocationRequest request);
    Task<bool> DeleteAsync(int id);
}