using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[] { new Guid("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad1"), null, "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[] { new Guid("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad2"), null, "Actividades personales", 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b47a76bf-0c1d-4e2c-bd74-ec2bde6e2ad2"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
