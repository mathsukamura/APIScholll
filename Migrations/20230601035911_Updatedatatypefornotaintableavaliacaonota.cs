using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class Updatedatatypefornotaintableavaliacaonota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "nota",
                table: "tb_avaliacao_nota",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "nota",
                table: "tb_avaliacao_nota",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
