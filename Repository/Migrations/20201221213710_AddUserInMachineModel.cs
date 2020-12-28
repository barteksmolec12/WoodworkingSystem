using Microsoft.EntityFrameworkCore.Migrations;

namespace JoineryUI.Data.Migrations
{
    public partial class AddUserInMachineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WoodmakerId",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_WoodmakerId",
                table: "Machines",
                column: "WoodmakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_AspNetUsers_WoodmakerId",
                table: "Machines",
                column: "WoodmakerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_AspNetUsers_WoodmakerId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_WoodmakerId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "WoodmakerId",
                table: "Machines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
