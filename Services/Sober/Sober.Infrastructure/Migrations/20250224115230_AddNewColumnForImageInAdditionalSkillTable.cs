using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnForImageInAdditionalSkillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AdditionalSkill",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AdditionalSkill");
        }
    }
}
