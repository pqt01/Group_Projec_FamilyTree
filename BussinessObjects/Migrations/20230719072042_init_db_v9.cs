using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class init_db_v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_Member_Couple",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Couple");

            migrationBuilder.RenameColumn(
                name: "CoupleId",
                table: "Member",
                newName: "MateId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_CoupleId",
                table: "Member",
                newName: "IX_Member_MateId");

            migrationBuilder.CreateTable(
                name: "Mate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mate_Mate",
                        column: x => x.ParentId,
                        principalTable: "Mate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mate_ParentId",
                table: "Mate",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Mate",
                table: "Member",
                column: "MateId",
                principalTable: "Mate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Mate",
                table: "Member");

            migrationBuilder.DropTable(
                name: "Mate");

            migrationBuilder.RenameColumn(
                name: "MateId",
                table: "Member",
                newName: "CoupleId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_MateId",
                table: "Member",
                newName: "IX_Member_CoupleId");

            migrationBuilder.CreateTable(
                name: "Couple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaId = table.Column<int>(type: "int", nullable: true),
                    MoId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couple", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Father_Couple_Member",
                        column: x => x.FaId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mother_Couple_Member",
                        column: x => x.MoId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parent_Couple_Couple",
                        column: x => x.ParentId,
                        principalTable: "Couple",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Couple_FaId",
                table: "Couple",
                column: "FaId");

            migrationBuilder.CreateIndex(
                name: "IX_Couple_MoId",
                table: "Couple",
                column: "MoId");

            migrationBuilder.CreateIndex(
                name: "IX_Couple_ParentId",
                table: "Couple",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_Member_Couple",
                table: "Member",
                column: "CoupleId",
                principalTable: "Couple",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
