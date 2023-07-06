using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class init_db_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Member",
                newName: "CoupleId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_ParentId",
                table: "Member",
                newName: "IX_Member_CoupleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoupleId",
                table: "Member",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_CoupleId",
                table: "Member",
                newName: "IX_Member_ParentId");
        }
    }
}
