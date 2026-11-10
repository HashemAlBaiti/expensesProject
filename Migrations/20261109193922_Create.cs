using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensesProject.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
