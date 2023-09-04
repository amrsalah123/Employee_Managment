using Microsoft.EntityFrameworkCore.Migrations;

namespace infrastructure.Migrations
{
    public partial class complete_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "salary",
                table: "employees",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "department",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "employees");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
