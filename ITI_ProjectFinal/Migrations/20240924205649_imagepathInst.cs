using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_ProjectFinal.Migrations
{
    /// <inheritdoc />
    public partial class imagepathInst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagepath",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagepath",
                table: "Courses");
        }
    }
}
