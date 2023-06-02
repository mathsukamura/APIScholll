using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedatatypefornotaintableHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "notafinal4",
                table: "tb_historico",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "notafinal3",
                table: "tb_historico",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "notafinal2",
                table: "tb_historico",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "notafinal1",
                table: "tb_historico",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "notafinal4",
                table: "tb_historico",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "notafinal3",
                table: "tb_historico",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "notafinal2",
                table: "tb_historico",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "notafinal1",
                table: "tb_historico",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
