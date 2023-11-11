using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.EntitiesUser;

public class Rol : IdentityRole<int>
{
    public string Description { get; set; }

    public override string Name
    {
        get { return base.Name; }
        set { base.Name = value; }
    }

    public override string NormalizedName
    {
        get => base.NormalizedName;
        set => base.NormalizedName = value;
    }
}