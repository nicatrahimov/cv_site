using NijatRahimov_CV_Site.Attributes;

namespace NijatRahimov_CV_Site.Requests.Services;

public class CreateServiceRequest
{
    public string Title { get; set; }
    [AllowedExtensions([".jpg",".png",".jpeg",".bmp",".tif",".tiff",".svg",".webp",".ico"])]
    public IFormFile? Image { get; set; }
}