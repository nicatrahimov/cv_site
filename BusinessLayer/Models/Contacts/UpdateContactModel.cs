namespace BusinessLayer.Models.Contacts;

public record UpdateContactModel(
    int Id,
    string Title,
    string Mail,
    string Phone);
