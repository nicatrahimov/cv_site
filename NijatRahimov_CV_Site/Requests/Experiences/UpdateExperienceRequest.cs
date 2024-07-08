using NijatRahimov_CV_Site.Attributes;

namespace NijatRahimov_CV_Site.Requests.Experiences;

public record UpdateExperienceRequest(
    int Id,
    string Name, 
    string Description,
    string CompanyName,
    DateTime DateFrom,
    DateTime? DateTo,
    [AllowedExtensions([".jpg",".png",".jpeg",".bmp",".tif",".tiff",".svg",".webp",".ico"])]
    IFormFile? Image);