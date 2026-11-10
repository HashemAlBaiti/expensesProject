using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensesProject.Migrations
{
    /// <inheritdoc />
    public partial class EditTableCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_UserCards_UserCartId",
                table: "Expensess");

            migrationBuilder.DropIndex(
                name: "IX_Expensess_UserCartId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "UserCartId",
                table: "Expensess");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess",
                column: "CatigoryId",
                principalTable: "Catigories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess");

            migrationBuilder.AddColumn<int>(
                name: "UserCartId",
                table: "Expensess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_UserCartId",
                table: "Expensess",
                column: "UserCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess",
                column: "CatigoryId",
                principalTable: "Catigories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_UserCards_UserCartId",
                table: "Expensess",
                column: "UserCartId",
                principalTable: "UserCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
