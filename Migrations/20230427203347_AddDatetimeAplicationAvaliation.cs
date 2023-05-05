using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class AddDatetimeAplicationAvaliation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAplicacao",
                table: "tb_avaliacao",
                newName: "Data_Aplicacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data_Aplicacao",
                table: "tb_avaliacao",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data_Aplicacao",
                table: "tb_avaliacao",
                newName: "DataAplicacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAplicacao",
                table: "tb_avaliacao",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }
    }
}
