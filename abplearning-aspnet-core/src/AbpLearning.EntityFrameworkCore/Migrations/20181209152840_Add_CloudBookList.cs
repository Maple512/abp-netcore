using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpLearning.EntityFrameworkCore.Migrations
{
    public partial class Add_CloudBookList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
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
                    Intro = table.Column<string>(maxLength: 256, nullable: true),
                    Url = table.Column<string>(maxLength: 128, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
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
                    TenantId = table.Column<int>(nullable: true)
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
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTag_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookTag_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookListAndBookRelationship",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    BookListId = table.Column<long>(nullable: false),
                    BookId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookListAndBookRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookListAndBookRelationship_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookListAndBookRelationship_BookList_BookListId",
                        column: x => x.BookListId,
                        principalTable: "BookList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookListAndBookRelationship_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookListAndBookRelationship_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAndBookTagRelationship",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    BookId = table.Column<long>(nullable: false),
                    BookTagId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAndBookTagRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAndBookTagRelationship_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAndBookTagRelationship_BookTag_BookTagId",
                        column: x => x.BookTagId,
                        principalTable: "BookTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAndBookTagRelationship_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAndBookTagRelationship_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CreatorUserId",
                table: "Book",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LastModifierUserId",
                table: "Book",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTagRelationship_BookId",
                table: "BookAndBookTagRelationship",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTagRelationship_BookTagId",
                table: "BookAndBookTagRelationship",
                column: "BookTagId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTagRelationship_CreatorUserId",
                table: "BookAndBookTagRelationship",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAndBookTagRelationship_LastModifierUserId",
                table: "BookAndBookTagRelationship",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_CreatorUserId",
                table: "BookList",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_LastModifierUserId",
                table: "BookList",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBookRelationship_BookId",
                table: "BookListAndBookRelationship",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBookRelationship_BookListId",
                table: "BookListAndBookRelationship",
                column: "BookListId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBookRelationship_CreatorUserId",
                table: "BookListAndBookRelationship",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBookRelationship_LastModifierUserId",
                table: "BookListAndBookRelationship",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_CreatorUserId",
                table: "BookTag",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_LastModifierUserId",
                table: "BookTag",
                column: "LastModifierUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAndBookTagRelationship");

            migrationBuilder.DropTable(
                name: "BookListAndBookRelationship");

            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookList");
        }
    }
}
