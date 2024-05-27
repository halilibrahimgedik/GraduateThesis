using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class addedUserClubApplicationFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clubPresidents",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clubPresidents", x => new { x.AppUserId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_clubPresidents_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clubPresidents_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppUserId",
                table: "Applications",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_clubPresidents_ClubId",
                table: "clubPresidents",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "clubPresidents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0e2320c3-0ce6-494f-b5eb-4401737a121b", "8a4c38e3-9d5f-4a48-96b8-1a557d4e6e59" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 10, 31, 42, 718, DateTimeKind.Local).AddTicks(5717));
        }
    }
}
