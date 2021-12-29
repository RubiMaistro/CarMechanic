using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMechanicWorkshop_Server.Migrations
{
    public partial class addDataTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Orders",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Orders");
        }
    }
}
