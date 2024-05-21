using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class AddedUniClubRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubUniversityId",
                table: "Clubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniversityId", "UserName" },
                values: new object[] { "35301441-b44f-4e60-92d1-bf29f86f8e33", 0, "9873cddf-6783-49b6-88ee-cf3475941892", "halilgedik4234@gmail.com", true, "Halil ibrahim gedik", false, null, null, null, null, null, false, "ab979c91-9c3f-4522-bb01-29fa3e162a24", false, 60, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClubUniversityId", "CreatedDate" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClubUniversityId", "CreatedDate" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClubUniversityId", "CreatedDate" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClubUniversityId", "CreatedDate", "Summary" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6201), "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?" });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClubUniversityId", "CreatedDate", "Summary" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6202), "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz!" });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClubUniversityId", "CreatedDate", "Summary" },
                values: new object[] { 60, new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6203), "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz!" });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubUniversityId",
                table: "Clubs",
                column: "ClubUniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Universities_ClubUniversityId",
                table: "Clubs",
                column: "ClubUniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Universities_ClubUniversityId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_ClubUniversityId",
                table: "Clubs");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33");

            migrationBuilder.DropColumn(
                name: "ClubUniversityId",
                table: "Clubs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 361, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Summary" },
                values: new object[] { new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(368), "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?  " });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Summary" },
                values: new object[] { new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(368), "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz! " });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Summary" },
                values: new object[] { new DateTime(2024, 5, 18, 22, 11, 47, 362, DateTimeKind.Local).AddTicks(369), "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz! " });
        }
    }
}
