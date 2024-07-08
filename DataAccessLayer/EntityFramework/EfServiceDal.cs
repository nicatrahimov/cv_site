using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public sealed class EfServiceDal : GenericRepository<Service>, IServiceDal
{
}