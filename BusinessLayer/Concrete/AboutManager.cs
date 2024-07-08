using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.About;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AboutManager(IAboutDal aboutDal, IAssetsStorageService assetsStorageService) : IAboutService
{
    private readonly string AboutFolderPath = Path.Combine(assetsStorageService.GetStoragePath(), "Abouts");
    
    public async Task AddAsync(AddAboutModel addAboutModel)
    {
        var imagePath = "";
        
        if (addAboutModel.Image != null && !string.IsNullOrWhiteSpace(addAboutModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{addAboutModel.FileExtension}";

            var filePath = Path.Combine(AboutFolderPath, fileName );

            await File.WriteAllBytesAsync(filePath, addAboutModel.Image);

            imagePath = filePath;
        }

        var about = new About(
            addAboutModel.Title,
            addAboutModel.Description,
            addAboutModel.Age,
            addAboutModel.Mail,
            addAboutModel.Phone,
            addAboutModel.Address,
            imagePath);
        
        await aboutDal.Insert(about);
    }

    public async Task DeleteAsync(int id)
    {
        var about = await aboutDal.GetById(id);

        if (!string.IsNullOrWhiteSpace(about.ImageUrl))
        {
            File.Delete(about.ImageUrl);
        }

        await aboutDal.Delete(about);
    }

    public async Task UpdateAsync(UpdateAboutModel updateServiceModel)
    {
        var imagePath = "";

        var existingAbout = await aboutDal.GetById(updateServiceModel.Id);

        if (updateServiceModel.Image != null && !string.IsNullOrWhiteSpace(updateServiceModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{updateServiceModel.FileExtension}";

            var filePath = Path.Combine(AboutFolderPath, fileName);

            await File.WriteAllBytesAsync(filePath, updateServiceModel.Image);

            imagePath = filePath;

            if (existingAbout.ImageUrl != null)
            {
                File.Delete(existingAbout.ImageUrl);
            }
        }
        else
        {
            if (existingAbout != null)
            {
                imagePath = existingAbout.ImageUrl;
            }
        }

        var about = new About(
            updateServiceModel.Title,
            updateServiceModel.Description,
            updateServiceModel.Age,
            updateServiceModel.Mail,
            updateServiceModel.Phone,
            updateServiceModel.Address,
            imagePath);
        
        about.AboutId = updateServiceModel.Id;
        
        await aboutDal.Update(about);
    }

    public async Task<IImmutableList<GetAboutModel>> GetAllAsync()
    {
        var abouts = await aboutDal.GetAll();

        var getAboutModels = new List<GetAboutModel>();

        foreach (var about in abouts)
        {
            byte[]? image = null;

            if (!string.IsNullOrWhiteSpace(about.ImageUrl))
            {
                image = await File.ReadAllBytesAsync(about.ImageUrl);
            }

            getAboutModels.Add(new(
                about.AboutId,
                about.Title,
                about.Description,
                about.Age,
                about.Mail,
                about.Phone,
                about.Address,
                image));
        }

        return getAboutModels.ToImmutableList();
    }

    public async Task<GetAboutModel> GetByIdAsync(int id)
    {
        var about = await aboutDal.GetById(id);

        byte[]? image = null;

        if (!string.IsNullOrWhiteSpace(about.ImageUrl))
        {
            image = File.ReadAllBytes(about.ImageUrl);
        }

        return new GetAboutModel(
            about.AboutId,
            about.Title,
            about.Description,
            about.Age,
            about.Mail,
            about.Phone,
            about.Address,
            image);
    }
}