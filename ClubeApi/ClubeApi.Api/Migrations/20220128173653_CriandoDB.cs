using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubeApi.Api.Migrations
{
    public partial class CriandoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Meses = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    senha = table.Column<string>(type: "CHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIOS_PESSOAS_Id",
                        column: x => x.Id,
                        principalTable: "PESSOAS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SOCIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroCartao = table.Column<decimal>(type: "NUMERIC(9)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Cep = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Uf = table.Column<string>(type: "CHAR(2)", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(25)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    FkCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOCIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOCIOS_CATEGORIAS_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "CATEGORIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOCIOS_PESSOAS_Id",
                        column: x => x.Id,
                        principalTable: "PESSOAS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DEPENDENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroCartao = table.Column<decimal>(type: "NUMERIC(9)", nullable: false),
                    Parentesco = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    FkSocio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPENDENTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DEPENDENTES_PESSOAS_Id",
                        column: x => x.Id,
                        principalTable: "PESSOAS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DEPENDENTES_SOCIOS_FkSocio",
                        column: x => x.FkSocio,
                        principalTable: "SOCIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MENSALIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vencimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    ValorInicial = table.Column<double>(type: "FLOAT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "DATE", nullable: true),
                    Juros = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 8),
                    ValorFinal = table.Column<double>(type: "FLOAT", nullable: true),
                    Quitada = table.Column<bool>(type: "BIT", nullable: false),
                    FkSocio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSALIDADES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MENSALIDADES_SOCIOS_FkSocio",
                        column: x => x.FkSocio,
                        principalTable: "SOCIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEPENDENTES_FkSocio",
                table: "DEPENDENTES",
                column: "FkSocio");

            migrationBuilder.CreateIndex(
                name: "IX_MENSALIDADES_FkSocio",
                table: "MENSALIDADES",
                column: "FkSocio");

            migrationBuilder.CreateIndex(
                name: "IX_SOCIOS_FkCategoria",
                table: "SOCIOS",
                column: "FkCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPENDENTES");

            migrationBuilder.DropTable(
                name: "FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "MENSALIDADES");

            migrationBuilder.DropTable(
                name: "SOCIOS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");

            migrationBuilder.DropTable(
                name: "PESSOAS");
        }
    }
}
