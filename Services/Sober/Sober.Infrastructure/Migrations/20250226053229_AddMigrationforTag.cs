using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationforTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Topics_TopicId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TopicId",
                table: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tags_TopicId",
                table: "Tags",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Topics_TopicId",
                table: "Tags",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
