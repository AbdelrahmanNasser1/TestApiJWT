using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiJWT.Migrations
{
    public partial class UpdateRelationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartments");

            migrationBuilder.RenameColumn(
                name: "ApartmentInfoId",
                table: "ImagesOfApartments",
                newName: "apartmentInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartments_ApartmentInfoId",
                table: "ImagesOfApartments",
                newName: "IX_ImagesOfApartments_apartmentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartments",
                column: "apartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartments");

            migrationBuilder.RenameColumn(
                name: "apartmentInfoId",
                table: "ImagesOfApartments",
                newName: "ApartmentInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartments_apartmentInfoId",
                table: "ImagesOfApartments",
                newName: "IX_ImagesOfApartments_ApartmentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_ApartmentInfoId",
                table: "ImagesOfApartments",
                column: "ApartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
