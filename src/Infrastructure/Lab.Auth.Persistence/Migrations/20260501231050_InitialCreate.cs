using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab.Auth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Isbn = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "BirthDate", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2f5fb6ae-0561-4b65-92f5-5a6f0ca6c7d1"), "Türk edebiyatının unutulmaz yazarlarından; toplumsal ve psikolojik derinliğiyle bilinir.", new DateTime(1907, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabahattin", "Ali", null },
                    { new Guid("4a3f34c3-8a7c-4cbc-9c24-1ff717a8ba4a"), "Nobel ödüllü yazar; İstanbul ve kimlik temalarıyla öne çıkar.", new DateTime(1952, 6, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orhan", "Pamuk", null },
                    { new Guid("8c3efaa3-3b94-4f17-bc2e-98e035a668cd"), "Anadolu insanını ve idealizmi merkeze alan klasik romanların yazarı.", new DateTime(1889, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reşat Nuri", "Güntekin", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1c3a3f8e-b6d4-4ef8-8e7f-56ad52c57d8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzun soluklu kurgu eserler.", "Roman", null },
                    { new Guid("2b5d5b82-2c80-4c03-8f4f-5a9b9d6b5c77"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Türk edebiyatının klasik kabul edilen eserleri.", "Klasik", null },
                    { new Guid("35ef77fa-5f76-48ec-9f84-6cc81857232e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yerel yazarların eserleri.", "Türk Edebiyatı", null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Country", "CreatedDate", "Name", "UpdatedDate", "Website" },
                values: new object[,]
                {
                    { new Guid("3a0d9b34-1c9a-4c57-8c31-8897e5b45ef2"), "Türkiye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İş Bankası Kültür Yayınları", null, "https://isbankyayinevi.com" },
                    { new Guid("5f2c3d90-9a8e-4cf0-8ef7-7e2bc9a5a111"), "Türkiye", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapı Kredi Yayınları", null, "https://kitap.ykykultur.com.tr" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedDate", "Description", "Isbn", "PublicationYear", "PublisherId", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a81f345-62fb-4fbe-9cde-52d69f964bce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orhan Pamuk’tan İstanbul’da geçen modern bir aşk romanı.", "9789750809572", 2008, new Guid("5f2c3d90-9a8e-4cf0-8ef7-7e2bc9a5a111"), "Masumiyet Müzesi", null },
                    { new Guid("8b1c1b79-fc6e-4d3a-9e55-6f2e2e4b3c10"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabahattin Ali’nin aşk ve yalnızlık temalarını işleyen klasiği.", "9789750805000", 1943, new Guid("5f2c3d90-9a8e-4cf0-8ef7-7e2bc9a5a111"), "Kürk Mantolu Madonna", null },
                    { new Guid("e2c73d7f-5123-4b7f-9cf7-9f1d0105d01c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reşat Nuri Güntekin’in idealist öğretmen Feride’nin hikâyesi.", "9789754700110", 1922, new Guid("3a0d9b34-1c9a-4c57-8c31-8897e5b45ef2"), "Çalıkuşu", null }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedDate", "Id", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4a3f34c3-8a7c-4cbc-9c24-1ff717a8ba4a"), new Guid("0a81f345-62fb-4fbe-9cde-52d69f964bce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("2f5fb6ae-0561-4b65-92f5-5a6f0ca6c7d1"), new Guid("8b1c1b79-fc6e-4d3a-9e55-6f2e2e4b3c10"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("8c3efaa3-3b94-4f17-bc2e-98e035a668cd"), new Guid("e2c73d7f-5123-4b7f-9cf7-9f1d0105d01c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("0a81f345-62fb-4fbe-9cde-52d69f964bce"), new Guid("1c3a3f8e-b6d4-4ef8-8e7f-56ad52c57d8f") },
                    { new Guid("0a81f345-62fb-4fbe-9cde-52d69f964bce"), new Guid("35ef77fa-5f76-48ec-9f84-6cc81857232e") },
                    { new Guid("8b1c1b79-fc6e-4d3a-9e55-6f2e2e4b3c10"), new Guid("2b5d5b82-2c80-4c03-8f4f-5a9b9d6b5c77") },
                    { new Guid("8b1c1b79-fc6e-4d3a-9e55-6f2e2e4b3c10"), new Guid("35ef77fa-5f76-48ec-9f84-6cc81857232e") },
                    { new Guid("e2c73d7f-5123-4b7f-9cf7-9f1d0105d01c"), new Guid("2b5d5b82-2c80-4c03-8f4f-5a9b9d6b5c77") },
                    { new Guid("e2c73d7f-5123-4b7f-9cf7-9f1d0105d01c"), new Guid("35ef77fa-5f76-48ec-9f84-6cc81857232e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Isbn",
                table: "Books",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
