using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchEngineRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddInvertedIndexBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Index");

            migrationBuilder.AddColumn<int>(
                name: "IndexOnType",
                table: "InvertedIndex",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Word",
                table: "InvertedIndex",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealeseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageIndex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvertedIndexBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvertedIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvertedIndexBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvertedIndexBooks_InvertedIndex_InvertedIndexId",
                        column: x => x.InvertedIndexId,
                        principalTable: "InvertedIndex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvertedIndexBooks_InvertedIndexId",
                table: "InvertedIndexBooks",
                column: "InvertedIndexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "InvertedIndexBooks");

            migrationBuilder.DropColumn(
                name: "IndexOnType",
                table: "InvertedIndex");

            migrationBuilder.DropColumn(
                name: "Word",
                table: "InvertedIndex");

            migrationBuilder.CreateTable(
                name: "Index",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvertedIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Invocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealeseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
