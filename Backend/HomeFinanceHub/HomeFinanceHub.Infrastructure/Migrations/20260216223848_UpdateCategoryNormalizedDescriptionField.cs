using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeFinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryNormalizedDescriptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedDescription",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedDescription",
                table: "Category");
        }
    }
}
