using BusinessLayer.Abstract;

namespace NijatRahimov_CV_Site.Services;

public class AssetsStorageManager(IWebHostEnvironment webHostEnvironment) : IAssetsStorageService
{
    public string GetStoragePath()
    {
        return Path.Combine(webHostEnvironment.WebRootPath, "Images");
    }
}