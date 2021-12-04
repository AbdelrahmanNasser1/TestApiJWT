using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiJWT.Migrations
{
    public partial class AddApartmentInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfApartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressOfApartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    floor = table.Column<int>(type: "int", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBathRooms = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    IsPrepaired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesOfApartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ApartmentInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesOfApartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesOfApartments_ApartmentInfos_ApartmentInfoId",
                        column: x => x.ApartmentInfoId,
                        principalTable: "ApartmentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesOfApartments_ApartmentInfoId",
                table: "ImagesOfApartments",
                column: "ApartmentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesOfApartments");

            migrationBuilder.DropTable(
                name: "ApartmentInfos");
        }
    }
}
