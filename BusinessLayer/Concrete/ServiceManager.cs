using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Services;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ServiceManager(IServiceDal serviceDal, IAssetsStorageService assetsStorageService) : IServiceService
{
    private readonly string ServiceFolderPath = Path.Combine(assetsStorageService.GetStoragePath(), "Services");

    public async Task AddAsync(AddServiceModel addServiceModel)
    {
        var imagePath = "";
        
        if (addServiceModel.Image != null && !string.IsNullOrWhiteSpace(addServiceModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{addServiceModel.FileExtension}";

            var filePath = Path.Combine(ServiceFolderPath, fileName );

            await File.WriteAllBytesAsync(filePath, addServiceModel.Image);

            imagePath = filePath;
        }

        var service = new Service(
            addServiceModel.Title,
            imagePath);
        
        await serviceDal.Insert(service);
    }
 

    public async Task DeleteAsync(int id)
    {
        var service = await serviceDal.GetById(id);

        if (!string.IsNullOrWhiteSpace(service?.ImageUrl))
        {
            File.Delete(service.ImageUrl);
        }

        if (service != null) await serviceDal.Delete(service);
    }

    public async Task UpdateAsync(UpdateServiceModel updateServiceModel)
    {
        var imagePath = "";

        var existingService = await serviceDal.GetById(updateServiceModel.Id);

        if (updateServiceModel.Image != null && !string.IsNullOrWhiteSpace(updateServiceModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{updateServiceModel.FileExtension}";

            var filePath = Path.Combine(ServiceFolderPath, fileName);

            await File.WriteAllBytesAsync(filePath, updateServiceModel.Image);

            imagePath = filePath;

            if (existingService.ImageUrl != null)
            {
                File.Delete(existingService.ImageUrl);
            }
        }
        else
        {
            if (existingService != null)
            {
                imagePath = existingService.ImageUrl;
            }
        }

        var service = new Service(
            updateServiceModel.Title,
            imagePath);
        
        service.ServiceId = updateServiceModel.Id;
        
        await serviceDal.Update(service);
    }

    public async Task<IImmutableList<GetServiceModel>> GetAllAsync()
    {
        var services = await serviceDal.GetAll();

        var getServiceModels = new List<GetServiceModel>();

        foreach (var service in services)
        {
            byte[]? image = null;

            if (!string.IsNullOrWhiteSpace(service.ImageUrl))
            {
                image = await File.ReadAllBytesAsync(service.ImageUrl);
            }
            getServiceModels.Add(new GetServiceModel(service.ServiceId, service.Title, image));
        }

        return getServiceModels.ToImmutableList();
    }

    public async Task<GetServiceModel> GetByIdAsync(int id)
    {
        var service = await serviceDal.GetById(id);

        byte[]? image = null;

        if (!string.IsNullOrWhiteSpace(service?.ImageUrl))
        {
            image = await File.ReadAllBytesAsync(service.ImageUrl);
        }
        
        return new GetServiceModel(
                service.ServiceId,
                service.Title,
                image);  
    }
}