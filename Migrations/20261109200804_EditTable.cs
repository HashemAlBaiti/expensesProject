using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensesProject.Migrations
{
    /// <inheritdoc />
    public partial class EditTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserCardsId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess",
                column: "CatigoryId",
                principalTable: "Catigories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users",
                column: "UserCardsId",
                principalTable: "UserCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserCardsId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess",
                column: "CatigoryId",
                principalTable: "Catigories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCards_UserCardsId",
                table: "Users",
                column: "UserCardsId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
