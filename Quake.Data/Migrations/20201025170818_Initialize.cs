using Microsoft.EntityFrameworkCore.Migrations;

namespace Quake.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "Description", "Lat", "Lng" },
                values: new object[] { 1L, null, "Vrlo oštećena zgrada", 20.300000000000001, 13.300000000000001 });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "Description", "Lat", "Lng" },
                values: new object[] { 2L, null, "Vrlo oštećena zgrada", 40.299999999999997, 30.300000000000001 });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "Description", "Lat", "Lng" },
                values: new object[] { 3L, null, "Manje oštećena zgrada", -13.300000000000001, 40.299999999999997 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
