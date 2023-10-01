using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace next_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Player_ID", "Age", "Date_Of_Birth", "Game_ID", "Name", "Park_ID" },
                values: new object[] { "1", null, "10/12/1992", null, "Paul", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Player_ID",
                keyValue: "1");
        }
    }
}
