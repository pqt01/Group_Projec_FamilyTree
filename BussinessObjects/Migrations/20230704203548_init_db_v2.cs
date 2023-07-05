using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BusinessObjects.Migrations
{
    public partial class init_db_v2 : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreateDate",
				table: "Image");
			migrationBuilder.AddColumn<DateTime>(
				name: "CreateDate",
				table: "Image",
				type: "datetime2",
				nullable: false,
				defaultValue: DateTime.Now);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CreateDate",
				table: "Image");
		}
	}
}
