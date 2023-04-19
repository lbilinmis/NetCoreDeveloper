using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentValidationApp.WebAPI.Migrations
{
    public partial class addEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "En_Gender",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "En_Gender",
                table: "Customers");
        }
    }
}
