using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelosParaEspecificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroContainer",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "NumeroBL",
                table: "BLs",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "DataEmissao",
                table: "BLs",
                newName: "Navio");

            migrationBuilder.RenameColumn(
                name: "Armador",
                table: "BLs",
                newName: "Consignee");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Containers",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "BLs",
                newName: "NumeroBL");

            migrationBuilder.RenameColumn(
                name: "Navio",
                table: "BLs",
                newName: "DataEmissao");

            migrationBuilder.RenameColumn(
                name: "Consignee",
                table: "BLs",
                newName: "Armador");

            migrationBuilder.AddColumn<string>(
                name: "NumeroContainer",
                table: "Containers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
