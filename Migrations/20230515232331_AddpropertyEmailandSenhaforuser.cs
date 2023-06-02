using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Scholl.Migrations
{
    /// <inheritdoc />
    public partial class AddpropertyEmailandSenhaforuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_login");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tb_usuario",
                type: "Varchar(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "tb_usuario",
                type: "Varchar(24)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "tb_usuario");

            migrationBuilder.CreateTable(
                name: "tb_login",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data_Registro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(24)", nullable: false),
                    n_celular = table.Column<string>(type: "varchar(15)", nullable: false),
                    username = table.Column<string>(type: "varchar(24)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_login", x => x.id);
                });
        }
    }
}
