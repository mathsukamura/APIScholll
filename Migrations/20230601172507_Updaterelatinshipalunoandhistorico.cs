using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class Updaterelatinshipalunoandhistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_historico_id_aluno",
                table: "tb_historico");

            migrationBuilder.CreateIndex(
                name: "IX_tb_historico_id_aluno",
                table: "tb_historico",
                column: "id_aluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_historico_id_aluno",
                table: "tb_historico");

            migrationBuilder.CreateIndex(
                name: "IX_tb_historico_id_aluno",
                table: "tb_historico",
                column: "id_aluno",
                unique: true);
        }
    }
}
