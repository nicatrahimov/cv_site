using System.Collections.Immutable;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete.Entities;

namespace BusinessLayer.Concrete;

public class MessageManager(IMessageDal messageDal) : IMessageService
{
    public async Task AddAsync(Message entity)
    {
        entity.Status = true;
        entity.Date =DateTime.UtcNow;
        await messageDal.Insert(entity);
    }

    public async Task DeleteAsync(Message entity)
    {
        await messageDal.Delete(entity);
    }

    public async Task UpdateAsync(Message entity)
    {
        await messageDal.Update(entity);
    }

    public async Task<IImmutableList<Message>> GetAllAsync()
    {
        return await messageDal.GetAll();
    }

    public async Task<Message> GetByIdAsync(int id)
    {
        return await messageDal.GetById(id);
    }

    public async Task MarkMessageAsRead(int messageId)
    {
        var message = await messageDal.GetById(messageId);
        message.Status = true;
        await messageDal.Update(message);
    }
}