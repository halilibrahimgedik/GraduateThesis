using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class FixedClubPresidentDeleteActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_AspNetUsers_AppUserId",
                table: "ClubPresidents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "abc879a9-0aec-4a20-a5db-a579ac9bf4c6", "1f2a1bf6-38b1-4463-8f9d-a86402035dee" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 18, 42, 31, 867, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPresidents_AspNetUsers_AppUserId",
                table: "ClubPresidents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_AspNetUsers_AppUserId",
                table: "ClubPresidents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents");

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
    }
}
