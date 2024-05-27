using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class changedAnnouncementTableColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Announcements",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Announcements",
                newName: "Message");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35301441-b44f-4e60-92d1-bf29f86f8e33",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "810302ad-f309-4763-a4f9-7efbfc3b79a5", "c812a000-33d5-4743-8f5f-9d268909c516" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 27, 20, 14, 56, 535, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Announcements",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Announcements",
                newName: "Publisher");

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
                name: "FK_ClubPresidents_Clubs_ClubId",
                table: "ClubPresidents",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");
        }
    }
}
