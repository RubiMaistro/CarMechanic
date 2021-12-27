using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMechanic_Server.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CarLicencePlateNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CarProblemDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WorkStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
