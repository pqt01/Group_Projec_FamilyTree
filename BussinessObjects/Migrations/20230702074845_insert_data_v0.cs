using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BusinessObjects.Migrations
{
    public partial class insert_data_v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                   "Users",
                   columns: new[] {
                        "Id",
                        "UserName",
                        "Email",
                        "SecurityStamp",
                        "EmailConfirmed",
                        "PhoneNumberConfirmed",
                        "TwoFactorEnabled",
                        "LockoutEnabled",
                        "AccessFailedCount",
                    },
                   values: new object[,] {
                        { "7B0E9F29-643A-4308-BEC7-316D7D7920DC", "admin1", "admin1@example.com",
                            Guid.NewGuid().ToString(),
                            true,
                            false,
                            false,
                            false,
                            0, },
                        { "9CCFD76D-0F48-42A7-8F30-54A3849DBE17", "member1", "member1@example.com",
                            Guid.NewGuid().ToString(),
                            true,
                            false,
                            false,
                            false,
                            0, },
                   }
               );
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { "E8C99166-52F3-4DF9-B792-705E1E9DBBD8", "Admin", "ADMIN", Guid.NewGuid().ToString()},
                    { "EE8E4CD1-101D-4887-A61E-789F481E0CD7", "Member", "MEMBER", Guid.NewGuid().ToString()},
                });
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "7B0E9F29-643A-4308-BEC7-316D7D7920DC", "E8C99166-52F3-4DF9-B792-705E1E9DBBD8" },
                    { "9CCFD76D-0F48-42A7-8F30-54A3849DBE17", "EE8E4CD1-101D-4887-A61E-789F481E0CD7" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
