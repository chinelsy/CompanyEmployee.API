using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployee.API.Migrations
{
    public partial class AddingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ef52b94-1a43-4cb4-a4e1-f806cdb447ea", "9f8bdbd8-a27a-4f23-b208-726995ba1e4e", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fce27bf-c6b6-4999-8f9c-b6433b4361f2", "27f1fc08-2be1-4cd3-925d-ddbca069c5bd", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef52b94-1a43-4cb4-a4e1-f806cdb447ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fce27bf-c6b6-4999-8f9c-b6433b4361f2");
        }
    }
}
