using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maibagamofisa.Migrations
{
    /// <inheritdoc />
    public partial class addtherestagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verb",
                table: "Verb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Verb",
                newName: "Verbs");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs",
                column: "VerbID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobID");

            migrationBuilder.CreateTable(
                name: "Daysoftheweek",
                columns: table => new
                {
                    DaysID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GermanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Daysof__BCE474CBEBF9F016", x => x.DaysID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daysoftheweek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Verbs",
                newName: "Verb");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verb",
                table: "Verb",
                column: "VerbID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobID");
        }
    }
}
