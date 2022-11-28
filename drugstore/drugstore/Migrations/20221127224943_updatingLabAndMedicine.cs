using Microsoft.EntityFrameworkCore.Migrations;

namespace drugstore.Migrations
{
    public partial class updatingLabAndMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabId",
                table: "Medicine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_LabId",
                table: "Medicine",
                column: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Lab_LabId",
                table: "Medicine",
                column: "LabId",
                principalTable: "Lab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Lab_LabId",
                table: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Medicine_LabId",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "Medicine");
        }
    }
}
