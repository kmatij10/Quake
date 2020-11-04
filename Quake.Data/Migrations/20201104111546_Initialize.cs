using Microsoft.EntityFrameworkCore.Migrations;

namespace Quake.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: false),
                    CardId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buildings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardType" },
                values: new object[,]
                {
                    { 1L, "Red" },
                    { 2L, "Yellow" },
                    { 3L, "Green" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1L, "Zagreb" },
                    { 2L, "Karlovac" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CardId", "CityId", "Description", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1L, "Strojarska 20", 1L, 1L, "Vrlo oštećena zgrada", 45.803226000000002, 15.989195 },
                    { 2L, "Ulica grada Vukovara 238", 2L, 1L, "Vrlo oštećena zgrada", 45.800562999999997, 15.994923999999999 },
                    { 3L, "Sumetlicka 39", 3L, 1L, "Manje oštećena zgrada", 45.799618000000002, 15.982284999999999 },
                    { 4L, "Ulica Kraljice Jelene 4", 3L, 1L, "Manje oštećena zgrada", 45.806241, 15.989720999999999 },
                    { 5L, "Pavla Hatza 20", 3L, 1L, "Manje oštećena zgrada", 45.807783999999998, 15.982132999999999 },
                    { 6L, "Ulica Baruna Trenka 2", 3L, 1L, "Manje oštećena zgrada", 45.807713999999997, 15.976683 },
                    { 7L, "Gunduliceva 12", 3L, 1L, "Manje oštećena zgrada", 45.810806999999997, 15.971931 },
                    { 8L, "Branjugova 6", 3L, 1L, "Manje oštećena zgrada", 45.814089000000003, 15.981847 },
                    { 9L, "Marticeva 63", 3L, 1L, "Manje oštećena zgrada", 45.812210999999998, 15.991466000000001 },
                    { 10L, "Tuskanova ulica 45", 3L, 1L, "Manje oštećena zgrada", 45.809514999999998, 15.997946000000001 },
                    { 11L, "Ulica Izidora Krsnjavog 2", 3L, 1L, "Manje oštećena zgrada", 45.807856000000001, 15.967188 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CardId",
                table: "Buildings",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityId",
                table: "Buildings",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
