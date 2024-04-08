using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maibagamofisa.Migrations
{
    /// <inheritdoc />
    public partial class addvegetableandanimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animals__A21A732716CDF226", x => x.AnimalID);
                });

            migrationBuilder.CreateTable(
                name: "Vegetable",
                columns: table => new
                {
                    VegetableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetable", x => x.VegetableID);
                });

           

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Colors__8DA7676DF8AC25CB", x => x.ColorID);
                    table.ForeignKey(
                        name: "FK__Colors__LessonID__4BAC3F29",
                        column: x => x.LessonID,
                        principalTable: "VocabularyLessons",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    FruitID = table.Column<int>(type: "int", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fruits__F33DDB2D3D8B0651", x => x.FruitID);
                    table.ForeignKey(
                        name: "PK__Fruits__F33DDB2D3D8B0651",
                        column: x => x.LessonID,
                        principalTable: "VocabularyLessons",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_LessonID",
                table: "Colors",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_LessonID",
                table: "Fruit",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fruit");

            migrationBuilder.DropTable(
                name: "Vegetable");

            migrationBuilder.DropTable(
                name: "VocabularyLessons");
        }
    }
}
