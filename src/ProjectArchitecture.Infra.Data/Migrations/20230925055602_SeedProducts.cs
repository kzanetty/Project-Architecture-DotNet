using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArchitecture.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name)" +
                "VALUES('Material Escolar')");

            migrationBuilder.Sql("INSERT INTO Categories(Name)" +
                "VALUES('Eletrônicos')");

            migrationBuilder.Sql("INSERT INTO Categories(Name)" +
                "VALUES('Material de construção')");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Caderno Espiral', 'caderno 100 folhas', 7.45, 50,'caderno1.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
                "VALUES('Estojo', 'Estojo preto', 4.45, 25,'estojo1.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
