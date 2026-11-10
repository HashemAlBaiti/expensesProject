using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensesProject.Migrations
{
    /// <inheritdoc />
    public partial class Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Expensess",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CatigoryId",
                table: "Expensess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpenseDate",
                table: "Expensess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Expensess",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "Expensess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Expensess",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "titile",
                table: "Expensess",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_CatigoryId",
                table: "Expensess",
                column: "CatigoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_PaymentMethodId",
                table: "Expensess",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensess_UserId",
                table: "Expensess",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess",
                column: "CatigoryId",
                principalTable: "Catigories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_PaymentMethods_PaymentMethodId",
                table: "Expensess",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Catigories_CatigoryId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_PaymentMethods_PaymentMethodId",
                table: "Expensess");

            migrationBuilder.DropForeignKey(
                name: "FK_Expensess_Users_UserId",
                table: "Expensess");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Expensess_CatigoryId",
                table: "Expensess");

            migrationBuilder.DropIndex(
                name: "IX_Expensess_PaymentMethodId",
                table: "Expensess");

            migrationBuilder.DropIndex(
                name: "IX_Expensess_UserId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "CatigoryId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "ExpenseDate",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expensess");

            migrationBuilder.DropColumn(
                name: "titile",
                table: "Expensess");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
