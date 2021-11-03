using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proj.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 1, "Chris Pine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming isn't about what you know; it's about what you can figure out" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 2, "Dennis Ritchie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The only way to learn a new programming language is by writing programs in it." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 3, "Joyce Wheeler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sometimes it's better to leave something alone, to pause, and that's very true of programming." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 4, "Burt Rutan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testing leads to failure, and failure leads to understanding." });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 5, "Grace Hopper", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The most damaging phrase in the language is.. it's always been done this way" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
