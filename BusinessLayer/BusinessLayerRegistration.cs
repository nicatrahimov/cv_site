using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer;

public static class BusinessLayerRegistration
{
    public static void RegisterBusinessLayer(this IServiceCollection services)
    {
        services.AddScoped<IFeatureService, FeatureManager>();
        
        services.AddScoped<IAboutService, AboutManager>();
        
        services.AddScoped<IServiceService, ServiceManager>();
        
        services.AddScoped<ISkillService, SkillManager>();

        services.AddScoped<IPortfolioService, PortfolioManager>();
        
        services.AddScoped<IExperienceService, ExperienceManager>();
        
        services.AddScoped<ITestimonialService, TestimonialManager>();
        
        services.AddScoped<IContactService, ContactManager>();
        
        services.AddScoped<IMessageService, MessageManager>();

        services.AddScoped<IAccessService, AccessManager>();
    }
}