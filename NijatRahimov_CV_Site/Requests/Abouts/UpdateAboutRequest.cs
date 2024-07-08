using NijatRahimov_CV_Site.Attributes;

namespace NijatRahimov_CV_Site.Requests.Abouts;

public class UpdateAboutRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Age { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; } 
    [AllowedExtensions([".jpg",".png",".jpeg",".bmp",".tif",".tiff",".svg",".webp",".ico"])]
    public IFormFile? Image { get; set; }
}