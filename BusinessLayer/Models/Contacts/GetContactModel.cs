namespace BusinessLayer.Models.Contacts;

public record GetContactModel(
    int Id,
    string Title,
    string Mail,
    string Phone);