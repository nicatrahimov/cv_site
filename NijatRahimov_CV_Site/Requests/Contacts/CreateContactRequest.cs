namespace NijatRahimov_CV_Site.Requests.Contacts;

public record CreateContactRequest(
    string Title,
    string Mail,
    string Phone);