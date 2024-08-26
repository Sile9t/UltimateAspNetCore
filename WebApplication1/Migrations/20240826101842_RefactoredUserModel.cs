using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be614dd-63fd-4fb4-b7ed-62fd4b0e8170");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7d5e947-40b2-4327-91a1-ab5ad130ae9c");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpityTime",
                table: "AspNetUsers",
                newName: "RefreshTokenExpiryTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "453c8ac2-4408-496a-8ef5-1e1008998350", null, "Administrator", "ADMINISTRATOR" },
                    { "fb051b83-d9fc-4ae1-b390-75d649a1bb96", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "453c8ac2-4408-496a-8ef5-1e1008998350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb051b83-d9fc-4ae1-b390-75d649a1bb96");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                newName: "RefreshTokenExpityTime");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8be614dd-63fd-4fb4-b7ed-62fd4b0e8170", null, "Manager", "MANAGER" },
                    { "c7d5e947-40b2-4327-91a1-ab5ad130ae9c", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
