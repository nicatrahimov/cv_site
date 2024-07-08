using System.Collections.Immutable;
using BusinessLayer.Models.Services;

namespace BusinessLayer.Abstract;

public interface IServiceService
{
    Task AddAsync(AddServiceModel addServiceModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateServiceModel updateServiceModel);
    Task<IImmutableList<GetServiceModel>> GetAllAsync();
    Task<GetServiceModel> GetByIdAsync(int id);
}