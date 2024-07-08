using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete.Entities;

namespace DataAccessLayer.EntityFramework;

public class EfMessageDal : GenericRepository<Message>, IMessageDal
{
}