namespace NijatRahimov_CV_Site.Requests.Contacts;

public record UpdateContactRequest(
    int Id,
    string Title,
    string Mail,
    string Phone);  