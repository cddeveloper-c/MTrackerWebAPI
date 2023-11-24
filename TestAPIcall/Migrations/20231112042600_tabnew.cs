using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPIcall.Migrations
{
    /// <inheritdoc />
    public partial class tabnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImageModels");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImageModels",
                newName: "ImageId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ImageModels",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ImageModels",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ImageModels");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "ImageModels",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ImageModels",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImageModels",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
