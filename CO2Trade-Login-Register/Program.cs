using System.Text;
using CO2Trade_Login_Register;
using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Repository;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Database
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
//Identity
builder.Services.AddIdentity<EntityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddResponseCaching();
//Automapper
builder.Services.AddAutoMapper(typeof(MappingConfig));
//Repository
builder.Services.AddScoped<IEntityUserRepository, EntityUserRepository>();
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//Service
builder.Services.AddScoped<IEntityUserService, EntityUsersService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
//Authentication
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
