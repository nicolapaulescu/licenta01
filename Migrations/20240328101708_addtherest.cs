using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maibagamofisa.Migrations
{
    /// <inheritdoc />
    public partial class addtherest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vegetable",
                table: "Vegetable");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Animal",
            //    table: "Animal");

            migrationBuilder.RenameTable(
                name: "Vegetable",
                newName: "Vegetables");

            migrationBuilder.RenameTable(
                name: "Fruit",
                newName: "Fruits");

            //migrationBuilder.RenameTable(
            //    name: "Animal",
            //    newName: "Animals");

            migrationBuilder.RenameIndex(
                name: "IX_Fruit_LessonID",
                table: "Fruits",
                newName: "IX_Fruits_LessonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vegetables",
                table: "Vegetables",
                column: "VegetableID");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Animals",
            //    table: "Animals",
            //    column: "AnimalID");

            migrationBuilder.CreateTable(
                name: "Body",
                columns: table => new
                {
                    BodyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Body__8545D8B5EA367D9D", x => x.BodyID);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__House__085D12AF5A9FA153", x => x.HouseID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jobs__056690E2BD94B84C", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    VerbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Verbs__B776A54E77B1A32E", x => x.VerbID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Body");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Verb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vegetables",
                table: "Vegetables");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Animals",
            //    table: "Animals");

            migrationBuilder.RenameTable(
                name: "Vegetables",
                newName: "Vegetable");

            migrationBuilder.RenameTable(
                name: "Fruits",
                newName: "Fruit");

            //migrationBuilder.RenameTable(
            //    name: "Animals",
            //    newName: "Animal");

            migrationBuilder.RenameIndex(
                name: "IX_Fruits_LessonID",
                table: "Fruit",
                newName: "IX_Fruit_LessonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vegetable",
                table: "Vegetable",
                column: "VegetableID");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Animal",
            //    table: "Animal",
            //    column: "AnimalID");
        }
    }
}
