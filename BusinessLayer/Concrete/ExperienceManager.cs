using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Experiences;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ExperienceManager(IExperienceDal experienceDal, IAssetsStorageService assetsStorageService) : IExperienceService
{
    private readonly string ExperienceFolderPath = Path.Combine(assetsStorageService.GetStoragePath(), "Experiences");

    
    public async Task AddAsync(AddExperienceModel addExperienceModel)
    {
        var imagePath = "";
        
        if (addExperienceModel.Image != null && !string.IsNullOrWhiteSpace(addExperienceModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{addExperienceModel.FileExtension}";

            var filePath = Path.Combine(ExperienceFolderPath, fileName );

            await File.WriteAllBytesAsync(filePath, addExperienceModel.Image);

            imagePath = filePath;
        }

        var service = new Experience(
            addExperienceModel.Name,
            addExperienceModel.DateFrom,
            addExperienceModel.DateTo,
            addExperienceModel.Description,
            addExperienceModel.CompanyName,
            imagePath);
        
        await experienceDal.Insert(service);
    }

    public async Task DeleteAsync(int id)
    {
        var experience = await experienceDal.GetById(id);

        if (!string.IsNullOrWhiteSpace(experience?.ImageUrl))
        {
            File.Delete(experience.ImageUrl);
        }

        if (experience != null)
        {
            await experienceDal.Delete(experience);
        }
    }

    public async Task UpdateAsync(UpdateExperienceModel updateExperienceModel)
    {
        var imagePath = "";

        var existingExperience = await experienceDal.GetById(updateExperienceModel.Id);

        if (updateExperienceModel.Image != null && !string.IsNullOrWhiteSpace(updateExperienceModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{updateExperienceModel.FileExtension}";

            var filePath = Path.Combine(ExperienceFolderPath, fileName);

            await File.WriteAllBytesAsync(filePath, updateExperienceModel.Image);

            imagePath = filePath;
    
            if (!string.IsNullOrWhiteSpace(existingExperience.ImageUrl))
            {
                File.Delete(existingExperience.ImageUrl);
            }
        }
        else
        {
            if (existingExperience != null)
            {
                imagePath = existingExperience.ImageUrl;
            }
        }

        var service = new Experience(
            updateExperienceModel.Name,
            updateExperienceModel.DateFrom,
            updateExperienceModel.DateTo,
            updateExperienceModel.Description,
            updateExperienceModel.CompanyName,
            imagePath);
        
        service.ExperienceId = updateExperienceModel.Id;
        
        await experienceDal.Update(service);
    }

    public async Task<IImmutableList<GetExperienceModel>> GetAllAsync()
    {
        var experiences = await experienceDal.GetAll();

        var getServiceModels = new List<GetExperienceModel>();

        foreach (var experience in experiences)
        {
            byte[]? image = null;

            if (!string.IsNullOrWhiteSpace(experience.ImageUrl))
            {
                image = await File.ReadAllBytesAsync(experience.ImageUrl);
            }
            getServiceModels.Add(new GetExperienceModel(
                experience.ExperienceId,
                experience.Name,
                experience.Description,
                experience.CompanyName,
                experience.DateFrom,
                experience.DateTo,
                image));
        }

        return getServiceModels.ToImmutableList();
    }

    public async Task<GetExperienceModel> GetByIdAsync(int id)
    {
        var experience = await experienceDal.GetById(id);

        byte[]? image = null;

        if (!string.IsNullOrWhiteSpace(experience?.ImageUrl))
        {
            image = await File.ReadAllBytesAsync(experience.ImageUrl);
        }
        
        return new GetExperienceModel(
            experience.ExperienceId,
            experience.Name,
            experience.Description,
            experience.CompanyName,
            experience.DateFrom,
            experience.DateTo,
            image);  
    }
}