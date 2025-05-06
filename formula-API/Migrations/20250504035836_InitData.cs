using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace formula_API.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Formulas",
                columns: table => new
                {
                    FormulaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    StepsData = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulas", x => x.FormulaId);
                    table.ForeignKey(
                        name: "FK_Formulas_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedBy", "CreatedDate", "Description", "ProductCode", "ProductName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "API", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Resep jamu untuk obat batuk", "PRD001", "Jamu Obat Batuk", null, null },
                    { 2, "API", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Resep jamu untuk nyeri haid", "PRD002", "Jamu Nyeri Haid", null, null }
                });

            migrationBuilder.InsertData(
                table: "Formulas",
                columns: new[] { "FormulaId", "CreatedBy", "CreatedDate", "ProductId", "StepsData", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "API", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1, "{\n      \"steps\": [\n        {\n          \"stepTitle\": \"Potong semua bahan\",\n          \"parameters\": {\n            \"deskripsi\": \"Memotong bahan-bahan utama menjadi bagian kecil agar mudah direbus.\",\n            \"durasi\": 5,\n            \"suhu\": 27.0,\n            \"tekanan\": 1.0\n          },\n          \"sub_steps\": [\n            {\n              \"subStepTitle\": \"Potong kunyit\",\n              \"parameters\": {\n                \"deskripsi\": \"Kunyit dipotong kecil untuk memudahkan ekstraksi saat direbus.\",\n                \"durasi\": 1,\n                \"suhu\": 27.0,\n                \"tekanan\": 1.0\n              }\n            },\n            {\n              \"subStepTitle\": \"Potong kencur\",\n              \"parameters\": {\n                \"deskripsi\": \"Kencur dipotong kecil sesuai takaran.\",\n                \"durasi\": 1,\n                \"suhu\": 27.0,\n                \"tekanan\": 1.0\n              }\n            },\n            {\n              \"subStepTitle\": \"Potong temulawak\",\n              \"parameters\": {\n                \"deskripsi\": \"Temulawak diiris atau dicincang agar aroma keluar maksimal.\",\n                \"durasi\": 1,\n                \"suhu\": 27.0,\n                \"tekanan\": 1.0\n              }\n            },\n            {\n              \"subStepTitle\": \"Siapkan adas manis dan kembang blimbing wuluh\",\n              \"parameters\": {\n                \"deskripsi\": \"Bahan tambahan dipersiapkan tanpa perlu dipotong.\",\n                \"durasi\": 1,\n                \"suhu\": 27.0,\n                \"tekanan\": 1.0\n              }\n            }\n          ]\n        },\n        {\n          \"stepTitle\": \"Rebus dengan air hingga mendidih\",\n          \"parameters\": {\n            \"deskripsi\": \"Campur semua bahan dengan 200 ml air dan rebus hingga mendidih. Matikan api setelah mendidih.\",\n            \"durasi\": 7,\n            \"suhu\": 100.0,\n            \"tekanan\": 1.0\n          }\n        },\n        {\n          \"stepTitle\": \"Tunggu hangat lalu tambahkan madu/gula\",\n          \"parameters\": {\n            \"deskripsi\": \"Setelah rebusan sedikit dingin, tambahkan madu atau gula pasir sesuai selera. Siap diminum selagi hangat.\",\n            \"durasi\": 3,\n            \"suhu\": 40.0,\n            \"tekanan\": 1.0\n          }\n        }\n      ]\n    }", "Formulasi Jamu Obat Batuk", null, null },
                    { 2, "API", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2, "{\n    \"steps\": [\n      {\n        \"stepTitle\": \"Siapkan kunyit dan asam jawa\",\n        \"parameters\": {\n          \"deskripsi\": \"Iris kunyit dan siapkan asam jawa di dalam gelas.\",\n          \"durasi\": 3,\n          \"suhu\": 27.0,\n          \"tekanan\": 1.0\n        },\n        \"sub_steps\": [\n          {\n            \"subStepTitle\": \"Iris 2 ruas kunyit\",\n            \"parameters\": {\n              \"deskripsi\": \"Kunyit diiris tipis-tipis untuk memaksimalkan ekstraksi.\",\n              \"durasi\": 1,\n              \"suhu\": 27.0,\n              \"tekanan\": 1.0\n            }\n          },\n          {\n            \"subStepTitle\": \"Masukkan 1 sdt asam jawa\",\n            \"parameters\": {\n              \"deskripsi\": \"Asam jawa dilarutkan sebagian dalam air untuk menambah rasa asam.\",\n              \"durasi\": 1,\n              \"suhu\": 27.0,\n              \"tekanan\": 1.0\n            }\n          },\n          {\n            \"subStepTitle\": \"Tuang 1 gelas air mendidih\",\n            \"parameters\": {\n              \"deskripsi\": \"Air panas membantu melarutkan zat aktif dari bahan.\",\n              \"durasi\": 1,\n              \"suhu\": 100.0,\n              \"tekanan\": 1.0\n            }\n          }\n        ]\n      },\n      {\n        \"stepTitle\": \"Tambahkan jeruk nipis\",\n        \"parameters\": {\n          \"deskripsi\": \"Masukkan irisan jeruk nipis untuk menambah rasa segar.\",\n          \"durasi\": 1,\n          \"suhu\": 40.0,\n          \"tekanan\": 1.0\n        },\n        \"sub_steps\": [\n          {\n            \"subStepTitle\": \"Iris 1/2 jeruk nipis dan masukkan\",\n            \"parameters\": {\n              \"deskripsi\": \"Iris setengah jeruk nipis dan campurkan ke ramuan.\",\n              \"durasi\": 1,\n              \"suhu\": 40.0,\n              \"tekanan\": 1.0\n            }\n          }\n        ]\n      },\n      {\n        \"stepTitle\": \"Tambahkan pemanis dan aduk rata\",\n        \"parameters\": {\n          \"deskripsi\": \"Tambahkan 1 sachet madu dan gula pasir secukupnya. Aduk rata sebelum disajikan.\",\n          \"durasi\": 2,\n          \"suhu\": 35.0,\n          \"tekanan\": 1.0\n        },\n        \"sub_steps\": [\n          {\n            \"subStepTitle\": \"Tambahkan 1 sachet madu\",\n            \"parameters\": {\n              \"deskripsi\": \"Madu ditambahkan sebagai pemanis alami.\",\n              \"durasi\": 1,\n              \"suhu\": 35.0,\n              \"tekanan\": 1.0\n            }\n          },\n          {\n            \"subStepTitle\": \"Tambahkan gula pasir secukupnya\",\n            \"parameters\": {\n              \"deskripsi\": \"Gula pasir dapat disesuaikan dengan selera.\",\n              \"durasi\": 1,\n              \"suhu\": 35.0,\n              \"tekanan\": 1.0\n            }\n          }\n        ]\n      }\n    ]\n}", "Formulasi Jamu Nyeri Haid", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_ProductId",
                table: "Formulas",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formulas");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
