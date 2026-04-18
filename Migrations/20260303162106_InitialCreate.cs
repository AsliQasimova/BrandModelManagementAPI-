using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhoneApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Models_ModelId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ModelId",
                table: "Features");

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Features",
                newName: "ModelID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Models",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ModelID",
                table: "Features",
                column: "ModelID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Models_ModelID",
                table: "Features",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Models_ModelID",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ModelID",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Features",
                newName: "ModelId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Models",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Features",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Xiaomi" },
                    { 2, "Samsung" },
                    { 3, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ID", "BrandID", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Xiaomi Redmi 12", 300m, 50 },
                    { 2, 1, "Xiaomi Mi 11", 500m, 30 },
                    { 3, 1, "Xiaomi Poco X4", 400m, 20 },
                    { 4, 2, "Samsung Galaxy S22", 800m, 25 },
                    { 5, 2, "Samsung Galaxy A52", 350m, 40 },
                    { 6, 2, "Samsung Galaxy Z Flip", 1000m, 10 },
                    { 7, 3, "iPhone 13", 900m, 20 },
                    { 8, 3, "iPhone 12", 700m, 30 },
                    { 9, 3, "iPhone SE", 400m, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_ModelId",
                table: "Features",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Models_ModelId",
                table: "Features",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
