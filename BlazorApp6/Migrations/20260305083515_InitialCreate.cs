using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    au_id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    au_fname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    au_lname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    contract = table.Column<bool>(type: "bit", nullable: false),
                    rowversion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.au_id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    pub_id = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    pub_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.pub_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    stor_id = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    stor_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    stor_addr = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    city = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    state = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.stor_id);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    title_id = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    type = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    advance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    royalty = table.Column<int>(type: "int", nullable: true),
                    ytd_sales = table.Column<int>(type: "int", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    pubdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pub_id = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.title_id);
                    table.ForeignKey(
                        name: "FK_titles_publishers_pub_id",
                        column: x => x.pub_id,
                        principalTable: "publishers",
                        principalColumn: "pub_id");
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    stor_id = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ord_num = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title_id = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ord_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    payterms = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => new { x.stor_id, x.ord_num, x.title_id });
                    table.ForeignKey(
                        name: "FK_sales_stores_stor_id",
                        column: x => x.stor_id,
                        principalTable: "stores",
                        principalColumn: "stor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_titles_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "title_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titleauthor",
                columns: table => new
                {
                    au_id = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    title_id = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    au_ord = table.Column<byte>(type: "tinyint", nullable: true),
                    royaltyper = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titleauthor", x => new { x.au_id, x.title_id });
                    table.ForeignKey(
                        name: "FK_titleauthor_authors_au_id",
                        column: x => x.au_id,
                        principalTable: "authors",
                        principalColumn: "au_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_titleauthor_titles_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "title_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sales_title_id",
                table: "sales",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_titleauthor_title_id",
                table: "titleauthor",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_titles_pub_id",
                table: "titles",
                column: "pub_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "titleauthor");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
