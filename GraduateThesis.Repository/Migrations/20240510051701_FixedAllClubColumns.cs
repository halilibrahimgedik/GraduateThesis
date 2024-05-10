using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class FixedAllClubColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClubActive",
                table: "Clubs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "ClubSummary",
                table: "Clubs",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "ClubPhoto",
                table: "Clubs",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ClubName",
                table: "Clubs",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3654));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 8, 17, 1, 228, DateTimeKind.Local).AddTicks(3901));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Clubs",
                newName: "ClubPhoto");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Clubs",
                newName: "ClubSummary");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clubs",
                newName: "ClubName");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Clubs",
                newName: "IsClubActive");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 7, 1, 2, 11, 328, DateTimeKind.Local).AddTicks(9498));
        }
    }
}
