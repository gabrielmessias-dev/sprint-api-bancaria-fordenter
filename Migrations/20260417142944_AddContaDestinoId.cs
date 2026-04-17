using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_bancaria.Migrations
{
    /// <inheritdoc />
    public partial class AddContaDestinoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaDestinoId",
                table: "Transacoes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaDestinoId",
                table: "Transacoes");
        }
    }
}
