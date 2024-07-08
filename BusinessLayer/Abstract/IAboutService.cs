using System.Collections.Immutable;
using BusinessLayer.Models.About;

namespace BusinessLayer.Abstract;

public interface IAboutService
{
    Task AddAsync(AddAboutModel addAboutModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateAboutModel updateServiceModel);
    Task<IImmutableList<GetAboutModel>> GetAllAsync();
    Task<GetAboutModel> GetByIdAsync(int id);
} 