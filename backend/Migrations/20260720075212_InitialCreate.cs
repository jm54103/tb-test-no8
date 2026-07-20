using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    AnswerChoiceNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Answer1Detail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Answer2Detail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Answer3Detail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Answer4Detail = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RecordTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");
        }
    }
}
