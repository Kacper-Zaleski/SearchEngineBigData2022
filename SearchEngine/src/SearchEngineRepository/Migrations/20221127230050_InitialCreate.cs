using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchEngineRepository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvertedIndex",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvertedIndex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Index",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealeseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvertedIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Index", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Index_InvertedIndex_InvertedIndexId",
                        column: x => x.InvertedIndexId,
                        principalTable: "InvertedIndex",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Index_InvertedIndexId",
                table: "Index",
                column: "InvertedIndexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Index");

            migrationBuilder.DropTable(
                name: "InvertedIndex");
        }
    }
}
