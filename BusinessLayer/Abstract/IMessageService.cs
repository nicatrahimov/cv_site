using EntitiyLayer.Concrete;
using EntityLayer.Concrete.Entities;

namespace BusinessLayer.Abstract;

public interface IMessageService : IGenericService<Message>
{
    Task MarkMessageAsRead(int messageId);
}