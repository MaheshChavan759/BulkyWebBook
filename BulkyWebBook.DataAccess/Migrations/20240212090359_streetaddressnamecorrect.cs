using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWebBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class streetaddressnamecorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddredd",
                table: "companies",
                newName: "StreetAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "companies",
                newName: "StreetAddredd");
        }
    }
}
