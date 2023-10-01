using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace next_api.Migrations
{
    /// <inheritdoc />
    public partial class addPlayerIdToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Player_ID",
                table: "Game",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player_ID",
                table: "Game");
        }
    }
}
