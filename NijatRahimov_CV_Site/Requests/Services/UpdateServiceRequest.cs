namespace NijatRahimov_CV_Site.Requests.Services;

public record UpdateServiceRequest(int Id,string Title, string? FileExtension, IFormFile? Image);