using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactDal : GenericRepository<Contact>, IContactDal
{
}