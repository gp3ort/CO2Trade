using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Measure;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Models.Projects;
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
    public DbSet<Image> Images { get; set; }
    public DbSet<MeasureCO2> MeasureCo2s { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<OperationCertificate> OperationsCertificates { get; set; }
    public DbSet<EntityProject> EntityProjects { get; set; }
    public DbSet<OperationProject> OperationProjects { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Name = Enum.Roles.ADMIN.ToString(),
                    Description = "Administrator rol"
                },
                new Rol
                {
                    Id = 2,
                    Name = Enum.Roles.INDIVIDUAL_CUSTOMER.ToString(),
                    Description = "Individual customer rol"
                },
                new Rol
                {
                    Id = 3,
                    Name = Enum.Roles.ORGANIZATION.ToString(),
                    Description = "Organization rol"
                }
            );

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
                    IdProjectType = 1,
                    Name = "Project for TEST",
                    TonsOfOxygen = 25,
                    Price = 25,
                    Description = "Just a test project",
                    IdImage = 1,
                    Image = null
                }
            );

            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType
                {
                    Id = 1,
                    Name = "Forestales",
                    Description = "Proyectos forestales se centran en la gestión sostenible de bosques, abordando la conservación, la silvicultura y la biodiversidad"
                },
                new ProjectType
                    {
                        Id = 2,
                        Name = "Energías Renovables",
                        Description = "Estos proyectos buscan aprovechar fuentes de energía sostenibles como solar, eólica, hidroeléctrica y geotérmica"
                    },
                new ProjectType
                {
                    Id = 3,
                    Name = "Economías Circulares",
                    Description = "Proyectos de economía circular se enfocan en minimizar el desperdicio y maximizar la reutilización de recursos. Esto implica diseñar productos con ciclos de vida más largos, reciclar materiales y crear sistemas donde los desechos se convierten en insumos para otros procesos"
                },
                new ProjectType
                {
                    Id = 4,
                    Name = "Ciencia Aplicada",
                    Description = "La ciencia aplicada se refiere a la investigación científica dirigida a resolver problemas prácticos. Proyectos en este campo buscan aplicar los conocimientos científicos para desarrollar tecnologías, productos o soluciones que tengan impacto directo en la sociedad o la industria"
                },
                new ProjectType
                {
                    Id = 5,
                    Name = "Otros",
                    Description = "Esta categoría es amplia y puede incluir una variedad de proyectos que no se ajustan a las categorías anteriores. Puede abarcar desde iniciativas sociales hasta innovaciones tecnológicas, dependiendo de la naturaleza específica de los proyectos incluidos en esta categoría"
                }
            );
        }
}