using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateThesis.Repository.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 11, 55, 366, DateTimeKind.Local).AddTicks(9160));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 17, 23, 8, 2, 398, DateTimeKind.Local).AddTicks(4691));
        }
    }
}
