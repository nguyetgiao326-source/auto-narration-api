using AudioGuide.Model.Dtos;
using AudioGuide.Model.Entities;
using AudioGuide.Repository.Repositories;

namespace AudioGuide.Service;

public class LanguageService : ILanguageService
{
    private readonly IRepository<Language> _repo;

    public LanguageService(IRepository<Language> repo)
    {
        _repo = repo;
    }

    public async Task<List<LanguageDto>> GetActiveLanguagesAsync()
    {
        var all = await _repo.GetAllAsync();
        return all
            .Where(l => l.IsActive)
            .OrderBy(l => l.Id)
            .Select(l => new LanguageDto(l.Id, l.Code, l.Name))
            .ToList();
    }
}