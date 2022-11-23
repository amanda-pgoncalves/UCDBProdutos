using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCDBProdutos.Data.Migrations
{
    public partial class CriacaoTabelaPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeProduto = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
