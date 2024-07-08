namespace BusinessLayer.Models.Contacts;

public record AddContactModel(
    string Title,
    string Mail,
    string Phone);