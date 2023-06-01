using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBSportStore.Migrations
{
    /// <inheritdoc />
    public partial class PopularProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, ShortDescription, DetailedDescription, Price, " +
                "ImageUrl, ImageThumbnailUrl, IsFavoriteProduct, InStock, CategoryId)" +
                "VALUES('Camisa Sousa Esporte Clube', 'Descrição curta da camisa', 'Descrição detalhada da camisa'," +
                "'179.99', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'1', '1', '2')");
            migrationBuilder.Sql("INSERT INTO Products(Name, ShortDescription, DetailedDescription, Price, " +
                "ImageUrl, ImageThumbnailUrl, IsFavoriteProduct, InStock, CategoryId)" +
                "VALUES('Camisa Campinense Clube', 'Descrição curta da camisa', 'Descrição detalhada da camisa'," +
                "'149.99', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'0', '1', '3')");
            migrationBuilder.Sql("INSERT INTO Products(Name, ShortDescription, DetailedDescription, Price, " +
                "ImageUrl, ImageThumbnailUrl, IsFavoriteProduct, InStock, CategoryId)" +
                "VALUES('Atlético de Cajazeiras', 'Descrição curta da camisa', 'Descrição detalhada da camisa'," +
                "'177.99', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpJEQ-H4IAXFz19pHCXWKkFcPdJIba_p1-ZQ&usqp=CAU', " +
                "'0', '1', '2')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
