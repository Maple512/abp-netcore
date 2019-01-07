using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpLearning.EntityFrameworkCore.Migrations
{
    public partial class Add_CloudBookList_Migrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CBL");

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "CBL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    CoverImgUrl = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Author = table.Column<string>(maxLength: 32, nullable: false),
                    Intro = table.Column<string>(maxLength: 512, nullable: true),
                    Url = table.Column<string>(maxLength: 64, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookList",
                schema: "CBL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Intro = table.Column<string>(maxLength: 128, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookList_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookList_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookTag",
                schema: "CBL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    Color = table.Column<string>(maxLength: 7, nullable: false),
                    BookId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTag_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "CBL",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookListCell",
                schema: "CBL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sort = table.Column<byte>(nullable: false),
                    BookId = table.Column<long>(nullable: true),
                    BookListId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookListCell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookListCell_BookList_BookListId",
                        column: x => x.BookListId,
                        principalSchema: "CBL",
                        principalTable: "BookList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CreatorUserId",
                schema: "CBL",
                table: "Book",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LastModifierUserId",
                schema: "CBL",
                table: "Book",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_CreatorUserId",
                schema: "CBL",
                table: "BookList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_LastModifierUserId",
                schema: "CBL",
                table: "BookList",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListCell_BookListId",
                schema: "CBL",
                table: "BookListCell",
                column: "BookListId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_BookId",
                schema: "CBL",
                table: "BookTag",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookListCell",
                schema: "CBL");

            migrationBuilder.DropTable(
                name: "BookTag",
                schema: "CBL");

            migrationBuilder.DropTable(
                name: "BookList",
                schema: "CBL");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "CBL");
        }
    }
}
