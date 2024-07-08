using System.Collections.Immutable;
using BusinessLayer.Models.Experiences;

namespace BusinessLayer.Abstract;

public interface IExperienceService
{
    Task AddAsync(AddExperienceModel addExperienceModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateExperienceModel updateExperienceModel);
    Task<IImmutableList<GetExperienceModel>> GetAllAsync();
    Task<GetExperienceModel> GetByIdAsync(int id);
}