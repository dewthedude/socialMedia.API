using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Repository.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFeatures_MasterSubCategory_SubCategoryId",
                table: "MasterFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterFeatures",
                table: "MasterFeatures");

            migrationBuilder.RenameTable(
                name: "MasterFeatures",
                newName: "MasterFeature");

            migrationBuilder.RenameIndex(
                name: "IX_MasterFeatures_SubCategoryId",
                table: "MasterFeature",
                newName: "IX_MasterFeature_SubCategoryId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "MasterFeature",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "MasterFeature",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterFeature",
                table: "MasterFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFeature_MasterSubCategory_SubCategoryId",
                table: "MasterFeature",
                column: "SubCategoryId",
                principalTable: "MasterSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFeature_MasterSubCategory_SubCategoryId",
                table: "MasterFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterFeature",
                table: "MasterFeature");

            migrationBuilder.RenameTable(
                name: "MasterFeature",
                newName: "MasterFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_MasterFeature_SubCategoryId",
                table: "MasterFeatures",
                newName: "IX_MasterFeatures_SubCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "IsDeleted",
                table: "MasterFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "MasterFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterFeatures",
                table: "MasterFeatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFeatures_MasterSubCategory_SubCategoryId",
                table: "MasterFeatures",
                column: "SubCategoryId",
                principalTable: "MasterSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
