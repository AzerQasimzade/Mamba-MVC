using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MambaTemplate.Migrations
{
    public partial class AddImageworker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Workers");
        }
    }
}
