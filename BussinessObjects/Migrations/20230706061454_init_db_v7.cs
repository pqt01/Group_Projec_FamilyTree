using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class init_db_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Couple",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Couple_ParentId",
                table: "Couple",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_Couple_Couple",
                table: "Couple",
                column: "ParentId",
                principalTable: "Couple",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_Couple_Couple",
                table: "Couple");

            migrationBuilder.DropIndex(
                name: "IX_Couple_ParentId",
                table: "Couple");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Couple");
        }
    }
}
