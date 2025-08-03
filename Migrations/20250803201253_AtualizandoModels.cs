using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SaborPizza",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SaborPizza",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
