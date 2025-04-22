using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init0919 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColumnFour",
                table: "UserCategoryGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOne",
                table: "UserCategoryGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnThree",
                table: "UserCategoryGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnTwo",
                table: "UserCategoryGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnFour",
                table: "UserCategoryGroups");

            migrationBuilder.DropColumn(
                name: "ColumnOne",
                table: "UserCategoryGroups");

            migrationBuilder.DropColumn(
                name: "ColumnThree",
                table: "UserCategoryGroups");

            migrationBuilder.DropColumn(
                name: "ColumnTwo",
                table: "UserCategoryGroups");
        }
    }
}
