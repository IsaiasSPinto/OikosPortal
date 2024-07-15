using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OikosPortal.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d20b5e4-8c4e-473b-88ff-284370e332ab", null, "Assinante", "ASSINANTE" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d20b5e4-8c4e-473b-88ff-284370e332ab");
        }
    }
}
