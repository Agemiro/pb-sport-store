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
                "'1', '1', '1')");
            migrationBuilder.Sql("INSERT INTO Products(Name, ShortDescription, DetailedDescription, Price, " +
                "ImageUrl, ImageThumbnailUrl, IsFavoriteProduct, InStock, CategoryId)" +
                "VALUES('Camisa Nacional de Patos', 'Descrição curta da camisa', 'Descrição detalhada da camisa'," +
                "'174.99', 'https://static.netshoes.com.br/produtos/camisa-nacional-de-patos-i-2021-robrac-paraiba-paraibano/60/72S-0001-060/72S-0001-060_zoom1.jpg?ts=1640034026', " +
                "'https://static.netshoes.com.br/produtos/camisa-nacional-de-patos-i-2021-robrac-paraiba-paraibano/60/72S-0001-060/72S-0001-060_zoom1.jpg?ts=1640034026', " +
                "'0', '1', '1')");
            migrationBuilder.Sql("INSERT INTO Products(Name, ShortDescription, DetailedDescription, Price, " +
                "ImageUrl, ImageThumbnailUrl, IsFavoriteProduct, InStock, CategoryId)" +
                "VALUES('Camisa Atlético de Cajazeiras', 'Descrição curta da camisa', 'Descrição detalhada da camisa'," +
                "'177.99', 'https://1.bp.blogspot.com/-KRMeQW4g-oc/YLeHKN8AZWI/AAAAAAAB0tA/whErG52pBGElPRFO0TsDDKlWRQiDtXuegCLcBGAsYHQ/s851/cajazeiras%2B%25281%2529.jpg', " +
                "'https://1.bp.blogspot.com/-KRMeQW4g-oc/YLeHKN8AZWI/AAAAAAAB0tA/whErG52pBGElPRFO0TsDDKlWRQiDtXuegCLcBGAsYHQ/s851/cajazeiras%2B%25281%2529.jpg', " +
                "'0', '1', '1')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
