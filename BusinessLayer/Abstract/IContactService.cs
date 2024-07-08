using System.Collections.Immutable;
using BusinessLayer.Models.Contacts;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IContactService
{
    Task AddAsync(AddContactModel addContactModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateContactModel updateContactModel);
    Task<IImmutableList<GetContactModel>> GetAllAsync();
    Task<GetContactModel> GetByIdAsync(int id);
}