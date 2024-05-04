using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClubActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubCategories",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubCategories", x => new { x.ClubId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ClubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubCategories_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Teknoloji", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5371), null },
                    { 2, "Spor", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5383), null },
                    { 3, "Kitap", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5385), null },
                    { 4, "Sanat", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5385), null },
                    { 5, "Dans", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5386), null },
                    { 6, "Girişimcilik", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5386), null }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "ClubName", "ClubPhoto", "ClubSummary", "CreatedDate", "IsClubActive", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "DU Siber", "default.jpg", "DU Siber Kulübü, öğrencilere teknoloji, yazılım ve siber güvenlik alanlarında deneyim kazanma imkanı sunar. Atölyeler, yarışmalar ve seminerlerle öğrenme ortamı sağlar. Katılın, teknolojiye adım atın ve kendinizi geliştirin!", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5610), true, null },
                    { 2, "Kitap Dostu", "default.jpg", "Kitap Dostu Kulübü, kitap tutkunlarını bir araya getirerek edebiyatın büyülü dünyasında yolculuğa çıkarır. Okuma tutkusunu paylaşan herkesi bekliyoruz!", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5612), true, null },
                    { 3, "DU Archer Club", "default.jpg", "DU Archer Club, okçuluk tutkunlarının buluşma noktasıdır. Okçuluk sporuna ilgi duyan herkesi bekliyoruz! ", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5613), true, null },
                    { 4, "DU Scout Club", "default.jpg", "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?  ", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5614), true, null },
                    { 5, "Elit Dans Kulübü", "default.jpg", "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz! ", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5614), true, null },
                    { 6, "The Young Entrepreneurs Club", "default.jpg", "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz! ", new DateTime(2024, 5, 4, 19, 42, 21, 532, DateTimeKind.Local).AddTicks(5615), true, null }
                });

            migrationBuilder.InsertData(
                table: "ClubCategories",
                columns: new[] { "CategoryId", "ClubId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubCategories_CategoryId",
                table: "ClubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubCategories");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
