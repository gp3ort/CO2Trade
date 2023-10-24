using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class ImageRepository : Repository<Image>, IImageRepository
{
    private readonly ApplicationDbContext _db;

    public ImageRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}