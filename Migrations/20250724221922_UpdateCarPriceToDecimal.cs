using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSeller.Migrations
{
    public partial class UpdateCarPriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_OwnerId",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "User",
                type: "NVARCHAR(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                type: "NVARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "User",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "User",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Car",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Car",
                type: "NVARCHAR(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_OwnerId",
                table: "Car",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_OwnerId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Car",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Car",
                type: "NVARCHAR",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_OwnerId",
                table: "Car",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
