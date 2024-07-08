using System.Collections.Immutable;
using BusinessLayer.Models.Testimonials;

namespace BusinessLayer.Abstract;

public interface ITestimonialService
{
    Task AddAsync(AddTestimonialModel addTestimonialModel);
    Task DeleteAsync(int id);
    Task UpdateAsync(UpdateTestimonialModel updateTestimonialModel);
    Task<IImmutableList<GetTestimonialModel>> GetAllAsync();
    Task<GetTestimonialModel> GetByIdAsync(int id);
}