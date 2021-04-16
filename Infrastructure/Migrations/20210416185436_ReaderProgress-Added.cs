using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ReaderProgressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookmarks_AspNetUsers_AuthorId",
                table: "AuthorBookmarks");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ReaderProgresses",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CountToComplete = table.Column<int>(nullable: false),
                    PagesPerDay = table.Column<int>(nullable: false),
                    AveragePerformance = table.Column<int>(nullable: false),
                    LastDayPagesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaderProgresses", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_ReaderProgresses_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReaderProgresses_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReaderProgresses_AuthorId",
                table: "ReaderProgresses",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookmarks_AspNetUsers_AuthorId",
                table: "AuthorBookmarks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookmarks_AspNetUsers_AuthorId",
                table: "AuthorBookmarks");

            migrationBuilder.DropTable(
                name: "ReaderProgresses");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookmarks_AspNetUsers_AuthorId",
                table: "AuthorBookmarks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
