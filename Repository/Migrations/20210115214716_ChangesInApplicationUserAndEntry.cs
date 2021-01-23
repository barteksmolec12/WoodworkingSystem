using Microsoft.EntityFrameworkCore.Migrations;

namespace JoineryUI.Data.Migrations
{
    public partial class ChangesInApplicationUserAndEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Entries");

            migrationBuilder.AddColumn<long>(
                name: "Token",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<long>(
                name: "Token",
                table: "Entries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
