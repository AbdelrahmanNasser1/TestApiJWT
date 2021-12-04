using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiJWT.Migrations
{
    public partial class UpdateDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesOfApartments",
                table: "ImagesOfApartments");

            migrationBuilder.RenameTable(
                name: "ImagesOfApartments",
                newName: "ImagesOfApartment");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartments_apartmentInfoId",
                table: "ImagesOfApartment",
                newName: "IX_ImagesOfApartment_apartmentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesOfApartment",
                table: "ImagesOfApartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartment",
                column: "apartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesOfApartment_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesOfApartment",
                table: "ImagesOfApartment");

            migrationBuilder.RenameTable(
                name: "ImagesOfApartment",
                newName: "ImagesOfApartments");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesOfApartment_apartmentInfoId",
                table: "ImagesOfApartments",
                newName: "IX_ImagesOfApartments_apartmentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesOfApartments",
                table: "ImagesOfApartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesOfApartments_ApartmentInfos_apartmentInfoId",
                table: "ImagesOfApartments",
                column: "apartmentInfoId",
                principalTable: "ApartmentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
