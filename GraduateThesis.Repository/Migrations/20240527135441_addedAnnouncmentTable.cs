using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class addedAnnouncmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clubPresidents_AspNetUsers_AppUserId",
                table: "clubPresidents");

            migrationBuilder.DropForeignKey(
                name: "FK_clubPresidents_Clubs_ClubId",
                table: "clubPresidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clubPresidents",
                table: "clubPresidents");

            migrationBuilder.RenameTable(
                name: "clubPresidents",
                newName: "ClubPresidents");

            migrationBuilder.RenameIndex(
                name: "IX_clubPresidents_ClubId",
                table: "ClubPresidents",
                newName: "IX_ClubPresidents_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubPresidents",
                table: "ClubPresidents",
                columns: new[] { "AppUserId", "ClubId" });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "91fb3af9-3e43-443d-8ede-8c9d30237d1d", "603d8e97-e36c-43bf-a7bb-0ac892a1aa9c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 16, 54, 41, 404, DateTimeKind.Local).AddTicks(5492));

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ClubId",
                table: "Announcements",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPresidents_AspNetUsers_AppUserId",
                table: "ClubPresidents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_AspNetUsers_AppUserId",
                table: "ClubPresidents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubPresidents",
                table: "ClubPresidents");

            migrationBuilder.RenameTable(
                name: "ClubPresidents",
                newName: "clubPresidents");

            migrationBuilder.RenameIndex(
                name: "IX_ClubPresidents_ClubId",
                table: "clubPresidents",
                newName: "IX_clubPresidents_ClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clubPresidents",
                table: "clubPresidents",
                columns: new[] { "AppUserId", "ClubId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72f16fb4-7c7b-4a8f-9c11-d348f617ef4f", "b08269cd-ea6a-48c2-817d-d43f10971cde" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 24, 17, 30, 56, 373, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.AddForeignKey(
                name: "FK_clubPresidents_AspNetUsers_AppUserId",
                table: "clubPresidents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clubPresidents_Clubs_ClubId",
                table: "clubPresidents",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
