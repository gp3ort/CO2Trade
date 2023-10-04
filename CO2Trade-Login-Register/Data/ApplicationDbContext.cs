using CO2Trade_Login_Register.Models.Billing;
using CO2Trade_Login_Register.Models.Documents;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Measure;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Models.Project;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CO2Trade_Login_Register.Data;

public class ApplicationDbContext : IdentityDbContext<EntityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    
    public DbSet<EntityUser> EntityUsers { get; set; }
    
    public DbSet<Rol> Roles { get; set; }

    public DbSet<EntityType> EntityTypes { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<TaxCondition> TaxConditions { get; set; }
    public DbSet<TaxDocumentType> TaxDocumentTypes { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<EntityDocument> EntityDocuments { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<MeasureCO2> MeasureCo2s { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<EntityProject> EntityProjects { get; set; }
    public DbSet<OperationProject> OperationProjects { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //modelbuilder.entity<rol>().hasdata(
        //        new rol
        //        {
        //            id = 1,
        //            name = enum.roles.admin.tostring(),
        //            description = "administrator rol"
        //        },
        //        new rol
        //        {
        //            id = 2,
        //            name = enum.roles.individual_customer.tostring(),
        //            description = "individual customer rol"
        //        },
        //        new rol
        //        {
        //            id = 3,
        //            name = enum.roles.organization.tostring(),
        //            description = "organization rol"
        //        }
        //    );

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
                    IdProjectType = 1,
                    ProjectType = null,
                    Description = "Just a test project",
                    IdImage = 1,
                    Image = null
                }
            );

            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType
                {
                    Id = 1,
                    Description = "Project type testing",
                });
        }
}