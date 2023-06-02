using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class Updatetablehistoricoaddmediafinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "mediafinal",
                table: "tb_historico",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mediafinal",
                table: "tb_historico");
        }
    }
}
