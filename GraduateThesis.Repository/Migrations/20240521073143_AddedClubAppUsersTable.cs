using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class AddedClubAppUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubAppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubAppUsers", x => new { x.AppUserId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_ClubAppUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubAppUsers_Clubs_ClubId",
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

            migrationBuilder.InsertData(
                table: "ClubAppUsers",
                columns: new[] { "AppUserId", "ClubId" },
                values: new object[,]
                {
                    { "c4652099-e1b3-4572-9b94-1462d39dd114", 1 },
                    { "c8bac547-a2d3-474c-87c4-dd2c1a1d1daa", 6 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ClubAppUsers_ClubId",
                table: "ClubAppUsers",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubAppUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9873cddf-6783-49b6-88ee-cf3475941892", "ab979c91-9c3f-4522-bb01-29fa3e162a24" });

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
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 6, 46, 9, 638, DateTimeKind.Local).AddTicks(6203));
        }
    }
}
