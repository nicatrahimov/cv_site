using System.Collections.Immutable;
using BusinessLayer.Abstract;
using BusinessLayer.Models.Testimonials;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class TestimonialManager(ITestimonialDal testimonialDal, IAssetsStorageService assetsStorageService) : ITestimonialService
{
    private readonly string TestimonialFolderPath = Path.Combine(assetsStorageService.GetStoragePath(), "Testimonials");
    
    public async Task AddAsync(AddTestimonialModel addTestimonialModel)
    {
        var imagePath = "";
        
        if (addTestimonialModel.Image != null && !string.IsNullOrWhiteSpace(addTestimonialModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{addTestimonialModel.FileExtension}";

            var filePath = Path.Combine(TestimonialFolderPath, fileName );

            await File.WriteAllBytesAsync(filePath, addTestimonialModel.Image);

            imagePath = filePath;
        }

        var testimonial = new Testimonial(
        addTestimonialModel.ClientName,
        addTestimonialModel.CompanyName,
        addTestimonialModel.Comment,
        imagePath);
        
        await testimonialDal.Insert(testimonial);
    }

    public async Task DeleteAsync(int id)
    {
        var service = await testimonialDal.GetById(id);

        if (!string.IsNullOrWhiteSpace(service?.ImageUrl))
        {
            File.Delete(service.ImageUrl);
        }

        if (service != null)
        {
            await testimonialDal.Delete(service);
        }
    }

    public async Task UpdateAsync(UpdateTestimonialModel updateTestimonialModel)
    {
        var imagePath = "";

        var existingService = await testimonialDal.GetById(updateTestimonialModel.Id);

        if (updateTestimonialModel.Image != null && !string.IsNullOrWhiteSpace(updateTestimonialModel.FileExtension))
        {
            var fileName = $"photo_{Guid.NewGuid()}{updateTestimonialModel.FileExtension}";

            var filePath = Path.Combine(TestimonialFolderPath, fileName);

            await File.WriteAllBytesAsync(filePath, updateTestimonialModel.Image);

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

        var testimonial = new Testimonial(
            updateTestimonialModel.ClientName,
            updateTestimonialModel.CompanyName,
            updateTestimonialModel.Comment,
            imagePath);
        
        testimonial.TestimonialId = updateTestimonialModel.Id;
        
        await testimonialDal.Update(testimonial);
    }

    public async Task<IImmutableList<GetTestimonialModel>> GetAllAsync()
    {
        var testimonials = await testimonialDal.GetAll();

        var getServiceModels = new List<GetTestimonialModel>();

        foreach (var testimonial in testimonials)
        {
            byte[]? image = null;

            if (!string.IsNullOrWhiteSpace(testimonial.ImageUrl))
            {
                image = await File.ReadAllBytesAsync(testimonial.ImageUrl);
            }
            getServiceModels.Add(new GetTestimonialModel(
                testimonial.TestimonialId, 
                testimonial.ClientName, 
                testimonial.CompanyName,
                testimonial.Comment,
                image));
        }

        return getServiceModels.ToImmutableList(); 
    }

    public async Task<GetTestimonialModel> GetByIdAsync(int id)
    {
        var service = await testimonialDal.GetById(id);

        byte[]? image = null;

        if (!string.IsNullOrWhiteSpace(service?.ImageUrl))
        {
            image = await File.ReadAllBytesAsync(service.ImageUrl);
        }
        
        return new GetTestimonialModel(
            service.TestimonialId,
            service.ClientName,
            service.CompanyName,
            service.Comment,
            image);  
    }
}