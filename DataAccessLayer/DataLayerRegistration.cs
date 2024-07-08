using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DataLayerRegistration
{
    public static void RegisterDataLayer(this IServiceCollection services)
    {
        services.AddScoped<IFeatureDal, EfFeatureDal>();
        
        services.AddScoped<IAboutDal, EfAboutDal>();
        
        services.AddScoped<IServiceDal, EfServiceDal>();
        
        services.AddScoped<ISkillDal, EfSkillDal>();

        services.AddScoped<IPortfolioDal, EfPortfolioDal>();
        
        services.AddScoped<IExperienceDal, EfExperienceDal>();
        
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        
        services.AddScoped<IContactDal, EfContactDal>();
        
        services.AddScoped<IMessageDal, EfMessageDal>();

        services.AddScoped<IUserDal, EfUserDal>();
    }
}