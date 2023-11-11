using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Measure;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Models.Projects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CO2Trade_Login_Register.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, Rol, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<EntityUser> EntityUsers { get; set; }
    public DbSet<EntityType> EntityTypes { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<MeasureCO2> MeasureCo2s { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<OperationCertificate> OperationsCertificates { get; set; }
    public DbSet<EntityProject> EntityProjects { get; set; }
    public DbSet<OperationProject> OperationProjects { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Purchase> Purchases { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Tablas de Identity
        modelBuilder.Entity<IdentityUser<int>>().ToTable("Entites");
        modelBuilder.Entity<Rol>().ToTable("Roles");

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
            entity.Property(e => e.ConcurrencyStamp).IsConcurrencyToken();
        });

        modelBuilder.Entity<EntityType>().HasData(
            new EntityType
            {
                Id = 1,
                Description = "Individual Person"
            },
            new EntityType
            {
                Id = 2,
                Description = "Legal Entity"
            }
        );
            
        modelBuilder.Entity<Image>().HasData(
            new Image
            {
                Id = 1,
                FileNameURL = "Test for test",
                Description = "just testing"
            });

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "Project for TEST",
                TonsOfOxygen = 25,
                Price = 25,
                Description = "Just a test project",
                IdImage = 1,
                Image = null
            }
        );
    }
}