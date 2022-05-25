using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorBooksid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.author_id);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorBooks_authorBooksid",
                        column: x => x.authorBooksid,
                        principalTable: "AuthorBooks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorBookid = table.Column<int>(type: "int", nullable: true),
                    stock_id = table.Column<int>(type: "int", nullable: false),
                    message_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_AuthorBooks_AuthorBookid",
                        column: x => x.AuthorBookid,
                        principalTable: "AuthorBooks",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_type);
                    table.ForeignKey(
                        name: "FK_Categories_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    stock_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: true),
                    total_nr_of_books = table.Column<int>(type: "int", nullable: false),
                    borrowed_books = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_Library_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_Messages_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_admin = table.Column<bool>(type: "bit", nullable: true),
                    message_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Messages_message_id",
                        column: x => x.message_id,
                        principalTable: "Messages",
                        principalColumn: "message_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_authorBooksid",
                table: "Authors",
                column: "authorBooksid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorBookid",
                table: "Books",
                column: "AuthorBookid");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_book_id",
                table: "Categories",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Library_book_id",
                table: "Library",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_book_id",
                table: "Messages",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_message_id",
                table: "Users",
                column: "message_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AuthorBooks");
        }
    }
}
