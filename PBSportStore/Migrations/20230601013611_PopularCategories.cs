using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBSportStore.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" + 
                "VALUES('Futebol', 'Futebol é um esporte jogado com os pés')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" +
                "VALUES('Basquete', 'Basquete é um esporte jogado com as mãos')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
