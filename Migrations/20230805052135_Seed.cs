using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ACCOUNTs",
                columns: new[] { "ID", "PASSWORD", "USERNAME" },
                values: new object[] { 1, "TestPwd1", "Tester1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACCOUNTs",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
