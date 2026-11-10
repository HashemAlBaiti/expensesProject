using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensesProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserCardsId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCartId",
                table: "Expensess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCardsId",
                table: "Users",
                column: "UserCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_UserCartId",
                table: "Expensess",
                column: "UserCartId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_Email",
                table: "UserCards",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_UserCards_UserCartId",
                table: "Expensess",
                column: "UserCartId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users",
                column: "UserCardsId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_UserCards_UserCartId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserCards");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCardsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Expensess_UserCartId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "UserCardsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCartId",
                table: "Expensess");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");
        }
    }
}
