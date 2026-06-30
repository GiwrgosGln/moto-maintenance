using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoMaintenance.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMotorcycleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_motorcycles_manufacturers_manufacturer_id",
                table: "motorcycles");

            migrationBuilder.DropForeignKey(
                name: "fk_motorcycles_models_model_id",
                table: "motorcycles");

            migrationBuilder.AlterColumn<string>(
                name: "nickname",
                table: "motorcycles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "model_year",
                table: "motorcycles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "motorcycles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "ix_motorcycles_user_id",
                table: "motorcycles",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_motorcycles_manufacturers_manufacturer_id",
                table: "motorcycles",
                column: "manufacturer_id",
                principalTable: "manufacturers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_motorcycles_models_model_id",
                table: "motorcycles",
                column: "model_id",
                principalTable: "models",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_motorcycles_manufacturers_manufacturer_id",
                table: "motorcycles");

            migrationBuilder.DropForeignKey(
                name: "fk_motorcycles_models_model_id",
                table: "motorcycles");

            migrationBuilder.DropIndex(
                name: "ix_motorcycles_user_id",
                table: "motorcycles");

            migrationBuilder.AlterColumn<string>(
                name: "nickname",
                table: "motorcycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "model_year",
                table: "motorcycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "motorcycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "fk_motorcycles_manufacturers_manufacturer_id",
                table: "motorcycles",
                column: "manufacturer_id",
                principalTable: "manufacturers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_motorcycles_models_model_id",
                table: "motorcycles",
                column: "model_id",
                principalTable: "models",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
