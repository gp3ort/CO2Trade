using CO2Trade_Login_Register.Models.EntitiesUser;
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
        }
}