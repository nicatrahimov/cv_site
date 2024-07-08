using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfSkillDal : GenericRepository<Skill>, ISkillDal
{
}