using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndereçoCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "TamanhoPizza",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "TelefoneCliente",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Vendas");

            migrationBuilder.AddColumn<string>(
                name: "EndereçoCliente",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TamanhoPizza",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefoneCliente",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
