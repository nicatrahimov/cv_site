using System.Collections.Immutable;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class FeatureManager(IFeatureDal featureDal) : IFeatureService
{
    public async Task AddAsync(Feature entity)
    {
        await featureDal.Insert(entity);
    }

    public async Task DeleteAsync(Feature entity)
    {
        await featureDal.Delete(entity);
    }

    public async Task UpdateAsync(Feature entity)
    {
       await featureDal.Update(entity);
    }

    public async Task<IImmutableList<Feature>> GetAllAsync()
    {
        return await featureDal.GetAll();
    }

    public async Task<Feature?> GetByIdAsync(int id)
    {
        return await featureDal.GetById(id);
    }
}