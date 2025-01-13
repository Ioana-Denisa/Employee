using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifySecializationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Equipments_EquipmentID",
                table: "Specializations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Equipments_EquipmentID",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_EquipmentID",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_EquipmentID",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "Specializations");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationID",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockID",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_SpecializationID",
                table: "Equipments",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_StockID",
                table: "Equipments",
                column: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Specializations_SpecializationID",
                table: "Equipments",
                column: "SpecializationID",
                principalTable: "Specializations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Stocks_StockID",
                table: "Equipments",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Specializations_SpecializationID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Stocks_StockID",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_SpecializationID",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_StockID",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "SpecializationID",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "Specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_EquipmentID",
                table: "Stocks",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_EquipmentID",
                table: "Specializations",
                column: "EquipmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Equipments_EquipmentID",
                table: "Specializations",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Equipments_EquipmentID",
                table: "Stocks",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
