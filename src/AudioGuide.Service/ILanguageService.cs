using AudioGuide.Model.Dtos;

namespace AudioGuide.Service;

public interface ILanguageService
{
    Task<List<LanguageDto>> GetActiveLanguagesAsync();
}