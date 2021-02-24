using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliverIT.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    ValorOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoriaCalculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeDiasEmAtraso = table.Column<int>(type: "int", nullable: false),
                    MultaPercentualAplicada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JurosDiaPercentual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorCorrigido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoriaCalculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoriaCalculo_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemoriaCalculo_ContaId",
                table: "MemoriaCalculo",
                column: "ContaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemoriaCalculo");

            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
