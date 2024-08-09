using EntitiyLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Host=dpg-cqqbrgqj1k6c73df8a10-a.frankfurt-postgres.render.com;Port=5432;Database=personal_site_hkau;Username=nicat;Password=MLYNv0FG7swvOdmqoZ8JC9VlRVYMfxLg");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>()
            .ToTable("Abouts");

        modelBuilder.Entity<Contact>()
            .ToTable("Contacts");

        modelBuilder.Entity<Experience>()
            .ToTable("Experiences");

        modelBuilder.Entity<Feature>()
            .ToTable("Features");

        modelBuilder.Entity<Message>()
            .ToTable("Messages");

        modelBuilder.Entity<Portfolio>()
            .ToTable("Portfolios");

        modelBuilder.Entity<Service>()
            .ToTable("Services");
        
        modelBuilder.Entity<Skill>()
            .ToTable("Skills");

        modelBuilder.Entity<Testimonial>()
            .ToTable("Testimonials");
        
        modelBuilder.Entity<User>()
            .ToTable("PermittedUsers");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }  
    public DbSet<User> Users { get; set; }
}