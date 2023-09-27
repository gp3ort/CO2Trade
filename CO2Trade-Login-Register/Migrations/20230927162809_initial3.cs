using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CO2Trade_Login_Register.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntityType",
                table: "AspNetUsers",
                newName: "IdRol");

            migrationBuilder.AddColumn<int>(
                name: "IdEntityType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntityType",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdRol",
                table: "AspNetUsers",
                newName: "EntityType");
        }
    }
}
