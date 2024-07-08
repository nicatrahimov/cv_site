using System.Collections.Immutable;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SkillManager(ISkillDal skillDal) : ISkillService
{
    public async Task AddAsync(Skill entity)
    {
        await skillDal.Insert(entity);
    }

    public async Task DeleteAsync(Skill entity)
    {
        await skillDal.Delete(entity);
    }

    public async Task UpdateAsync(Skill entity)
    {
        await skillDal.Update(entity);
    }

    public async Task<IImmutableList<Skill>> GetAllAsync()
    {
        return await skillDal.GetAll();
    }

    public async Task<Skill> GetByIdAsync(int id)
    {
        return await skillDal.GetById(id);
    }
}