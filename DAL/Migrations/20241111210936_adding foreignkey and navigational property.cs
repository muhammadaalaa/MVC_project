using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addingforeignkeyandnavigationalproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmentID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentID",
                table: "Employees",
                column: "departmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentID",
                table: "Employees",
                column: "departmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departmentID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departmentID",
                table: "Employees");
        }
    }
}
