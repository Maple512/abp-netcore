using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpLearning.EntityFrameworkCore.Migrations
{
    public partial class Optimization_CloudBookList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTag",
                schema: "CBL");

            migrationBuilder.DropColumn(
                name: "ExsitedBookCount",
                schema: "CBL",
                table: "BookList");

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                schema: "CBL",
                table: "BookListCell",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                schema: "CBL",
                table: "BookList",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "CBL",
                table: "BookList",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                schema: "CBL",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "CBL",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagJSON",
                schema: "CBL",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookList_DeleterUserId",
                schema: "CBL",
                table: "BookList",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_DeleterUserId",
                schema: "CBL",
                table: "Book",
                column: "DeleterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Users_DeleterUserId",
                schema: "CBL",
                table: "Book",
                column: "DeleterUserId",
                principalSchema: "ABP",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookList_Users_DeleterUserId",
                schema: "CBL",
                table: "BookList",
                column: "DeleterUserId",
                principalSchema: "ABP",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Users_DeleterUserId",
                schema: "CBL",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookList_Users_DeleterUserId",
                schema: "CBL",
                table: "BookList");

            migrationBuilder.DropIndex(
                name: "IX_BookList_DeleterUserId",
                schema: "CBL",
                table: "BookList");

            migrationBuilder.DropIndex(
                name: "IX_Book_DeleterUserId",
                schema: "CBL",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                schema: "CBL",
                table: "BookList");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "CBL",
                table: "BookList");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                schema: "CBL",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "CBL",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TagJSON",
                schema: "CBL",
                table: "Book");

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                schema: "CBL",
                table: "BookListCell",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<byte>(
                name: "ExsitedBookCount",
                schema: "CBL",
                table: "BookList",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "BookTag",
                schema: "CBL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<long>(nullable: false),
                    Color = table.Column<string>(maxLength: 7, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    TenantId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_BookId",
                schema: "CBL",
                table: "BookTag",
                column: "BookId");
        }
    }
}
