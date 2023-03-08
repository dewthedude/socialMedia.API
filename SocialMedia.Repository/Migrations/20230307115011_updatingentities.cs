using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Repository.Migrations
{
    public partial class updatingentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MasterSubCategory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MasterFeature",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MasterCategory",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MasterSubCategory");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MasterFeature");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MasterCategory");
        }
    }
}
