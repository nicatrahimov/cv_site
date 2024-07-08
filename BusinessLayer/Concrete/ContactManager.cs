using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Contacts;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactManager(IContactDal contactDal) : IContactService
{
    public async Task AddAsync(AddContactModel addContactModel)
    {
        var contact = new Contact(
            addContactModel.Title,
            addContactModel.Mail,
            addContactModel.Phone);
        
        await contactDal.Insert(contact);
    }

    public async Task DeleteAsync(int id)
    {
        var contact = await contactDal.GetById(id);
        await contactDal.Delete(contact);
    }
    
    public async Task UpdateAsync(UpdateContactModel updateContactModel)
    {
        var contact = await contactDal.GetById(updateContactModel.Id);
        contact.Title = updateContactModel.Title;
        contact.Mail = updateContactModel.Mail;
        contact.Phone = updateContactModel.Phone;
        
        await contactDal.Update(contact);
    }

    public async Task<IImmutableList<GetContactModel>> GetAllAsync()
    {
        var contacts = await contactDal.GetAll();
        return contacts.Select(contact => new GetContactModel(
            contact.ContactId,
            contact.Title,
            contact.Mail,
            contact.Phone)).ToImmutableList();
    }

    public async Task<GetContactModel> GetByIdAsync(int id)
    {
        var contact = await contactDal.GetById(id);
        return new GetContactModel(
            contact.ContactId,
            contact.Title,
            contact.Mail,
            contact.Phone);
    }
}