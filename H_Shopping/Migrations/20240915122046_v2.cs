using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H_Shopping.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaptopSpecification_Products_SpecificationID",
                table: "LaptopSpecification");

            migrationBuilder.DropIndex(
                name: "IX_LaptopSpecification_SpecificationID",
                table: "LaptopSpecification");

            migrationBuilder.DropColumn(
                name: "SpecificationID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "LaptopSpecification");

            migrationBuilder.DropColumn(
                name: "SpecificationID",
                table: "LaptopSpecification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecificationID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "LaptopSpecification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SpecificationID",
                table: "LaptopSpecification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LaptopSpecification_SpecificationID",
                table: "LaptopSpecification",
                column: "SpecificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_LaptopSpecification_Products_SpecificationID",
                table: "LaptopSpecification",
                column: "SpecificationID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
