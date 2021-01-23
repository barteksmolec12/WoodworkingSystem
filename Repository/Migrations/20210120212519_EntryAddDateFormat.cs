using Microsoft.EntityFrameworkCore.Migrations;

namespace JoineryUI.Data.Migrations
{
    public partial class EntryAddDateFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimeIn",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeOut",
                table: "Entries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Entries");
        }
    }
}
