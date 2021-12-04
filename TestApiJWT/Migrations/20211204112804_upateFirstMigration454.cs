using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiJWT.Migrations
{
    public partial class upateFirstMigration454 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesOfApartment",
                table: "ImagesOfApartment");

            migrationBuilder.RenameTable(
                name: "ImagesOfApartment",
                newName: "ImagesOfApartments");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartment_ApartmentInfoId",
                table: "ImagesOfApartments",
                newName: "IX_ImagesOfApartments_ApartmentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesOfApartments",
                table: "ImagesOfApartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartments",
                column: "ApartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesOfApartments",
                table: "ImagesOfApartments");

            migrationBuilder.RenameTable(
                name: "ImagesOfApartments",
                newName: "ImagesOfApartment");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartments_ApartmentInfoId",
                table: "ImagesOfApartment",
                newName: "IX_ImagesOfApartment_ApartmentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesOfApartment",
                table: "ImagesOfApartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartment",
                column: "ApartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
