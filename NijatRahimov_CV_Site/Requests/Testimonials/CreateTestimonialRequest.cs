using NijatRahimov_CV_Site.Attributes;

namespace NijatRahimov_CV_Site.Requests.Testimonials;

public record CreateTestimonialRequest(
    string ClientName,
    string CompanyName,
    string Comment,
    [AllowedExtensions([".jpg",".png",".jpeg",".bmp",".tif",".tiff",".svg",".webp",".ico"])]
    IFormFile? Image);