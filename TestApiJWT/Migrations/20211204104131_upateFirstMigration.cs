using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiJWT.Migrations
{
    public partial class upateFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartment");

            migrationBuilder.RenameColumn(
                name: "apartmentInfoId",
                table: "ImagesOfApartment",
                newName: "ApartmentInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartment_apartmentInfoId",
                table: "ImagesOfApartment",
                newName: "IX_ImagesOfApartment_ApartmentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartment",
                column: "ApartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartment");

            migrationBuilder.RenameColumn(
                name: "ApartmentInfoId",
                table: "ImagesOfApartment",
                newName: "apartmentInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartment_ApartmentInfoId",
                table: "ImagesOfApartment",
                newName: "IX_ImagesOfApartment_apartmentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartment",
                column: "apartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
