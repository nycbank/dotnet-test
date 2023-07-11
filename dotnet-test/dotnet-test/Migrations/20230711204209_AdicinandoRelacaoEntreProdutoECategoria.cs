using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_test.Migrations
{
    /// <inheritdoc />
    public partial class AdicinandoRelacaoEntreProdutoECategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProdutos",
                columns: table => new
                {
                    Categoriasid = table.Column<int>(type: "int", nullable: false),
                    Produtosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProdutos", x => new { x.Categoriasid, x.Produtosid });
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Categorias_Categoriasid",
                        column: x => x.Categoriasid,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriasProdutos_Produtos_Produtosid",
                        column: x => x.Produtosid,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProdutos_Produtosid",
                table: "CategoriasProdutos",
                column: "Produtosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasProdutos");
        }
    }
}
