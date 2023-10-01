using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace next_api.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDocInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDocInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Icon_Background_Color = table.Column<string>(type: "TEXT", nullable: true),
                    Icon_Mask_Base_Uri = table.Column<string>(type: "TEXT", nullable: true),
                    International_Phone_Number = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Place_Id = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    User_Ratings_Total = table.Column<int>(type: "INTEGER", nullable: false),
                    Utc_Offset = table.Column<int>(type: "INTEGER", nullable: false),
                    Vicinity = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Sport_ID = table.Column<string>(type: "TEXT", nullable: false),
                    GameDocInfo_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Max_Num_Players = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Sport_ID);
                    table.ForeignKey(
                        name: "FK_Sport_GameDocInfos_GameDocInfo_ID",
                        column: x => x.GameDocInfo_ID,
                        principalTable: "GameDocInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressComponent",
                columns: table => new
                {
                    AddressComponent_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Long_name = table.Column<string>(type: "TEXT", nullable: false),
                    Short_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressComponent", x => x.AddressComponent_ID);
                    table.ForeignKey(
                        name: "FK_AddressComponent_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Closing_Hours",
                columns: table => new
                {
                    Week_day = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closing_Hours", x => x.Week_day);
                    table.ForeignKey(
                        name: "FK_Closing_Hours_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Game_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Place_id = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sport_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number_Of_Players = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTIme = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Game_ID);
                    table.ForeignKey(
                        name: "FK_Game_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Location_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Lat = table.Column<double>(type: "REAL", nullable: false),
                    Lng = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Location_ID);
                    table.ForeignKey(
                        name: "FK_Location_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Open_Hours",
                columns: table => new
                {
                    Week_Day = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Open_Hours", x => x.Week_Day);
                    table.ForeignKey(
                        name: "FK_Open_Hours_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Author_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Author_Url = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Profile_Photo_Url = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Relative_Time_Description = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Player_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Game_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date_Of_Birth = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Player_ID);
                    table.ForeignKey(
                        name: "FK_Player_Game_Game_ID",
                        column: x => x.Game_ID,
                        principalTable: "Game",
                        principalColumn: "Game_ID");
                    table.ForeignKey(
                        name: "FK_Player_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Geometry",
                columns: table => new
                {
                    Geometry_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Park_ID = table.Column<string>(type: "TEXT", nullable: true),
                    Location_ID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geometry", x => x.Geometry_ID);
                    table.ForeignKey(
                        name: "FK_Geometry_Location_Location_ID",
                        column: x => x.Location_ID,
                        principalTable: "Location",
                        principalColumn: "Location_ID");
                    table.ForeignKey(
                        name: "FK_Geometry_Park_Park_ID",
                        column: x => x.Park_ID,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GameDocInfos",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Sport",
                columns: new[] { "Sport_ID", "GameDocInfo_ID", "Max_Num_Players", "Name" },
                values: new object[,]
                {
                    { "1", 1, 12, "Basketball" },
                    { "2", 1, 12, "Football" },
                    { "3", 1, 12, "Soccer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressComponent_Park_ID",
                table: "AddressComponent",
                column: "Park_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Closing_Hours_Park_ID",
                table: "Closing_Hours",
                column: "Park_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_Park_ID",
                table: "Game",
                column: "Park_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Geometry_Location_ID",
                table: "Geometry",
                column: "Location_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Geometry_Park_ID",
                table: "Geometry",
                column: "Park_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Park_ID",
                table: "Location",
                column: "Park_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Open_Hours_Park_ID",
                table: "Open_Hours",
                column: "Park_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_Game_ID",
                table: "Player",
                column: "Game_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Park_ID",
                table: "Player",
                column: "Park_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Park_ID",
                table: "Review",
                column: "Park_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_GameDocInfo_ID",
                table: "Sport",
                column: "GameDocInfo_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressComponent");

            migrationBuilder.DropTable(
                name: "Closing_Hours");

            migrationBuilder.DropTable(
                name: "Geometry");

            migrationBuilder.DropTable(
                name: "Open_Hours");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameDocInfos");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
