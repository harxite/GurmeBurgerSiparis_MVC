using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class _2345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c072f0c0-d576-4097-9791-a6937dcba74f");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6040633-db1b-4a48-be54-9f214e77ac9d",
                column: "ConcurrencyStamp",
                value: "c7eb8f9d-3130-4fda-9c46-218b5b3eb425");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b5d8dfb-c8bd-4a24-9ba3-da6050808d0b", "9dff795f-6d7f-49fe-a0ef-bd8e24920e81", "Standard User", "STANDARD USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df5a9b38-18e8-48b7-97bf-ad4a9b4afe0e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2198a4e0-4d21-4c4b-af25-7fc398f90c12", "AQAAAAEAACcQAAAAENEiCW4zS4DDfh/dr9zvoMlKCFNVbTPxtOTU+ZxgzcerXAkI5+suXhG0ehXd5eqWag==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ImagePath", "ModifiedDate", "Name", "OrderId", "Price", "Quantity", "Size", "Status" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1361), null, null, "GuncelResimler/patates1.png", null, "Patates Kızartması", null, 30.0, 1, 0, 1 },
                    { 10, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1363), null, null, "GuncelResimler/onion.png", null, "Soğan Halkası", null, 30.0, 1, 0, 1 },
                    { 11, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1389), null, null, "GuncelResimler/sufle.png", null, "Sufle", null, 30.0, 1, 0, 1 },
                    { 12, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1390), null, null, "GuncelResimler/Nugget1.png", null, "Nugget", null, 30.0, 1, 0, 1 },
                    { 13, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1391), null, null, "GuncelResimler/MilkShake.png", null, "Çilekli Milkshake", null, 30.0, 1, 0, 1 },
                    { 14, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1392), null, null, "GuncelResimler/Kola1.png", null, "Kola", null, 30.0, 1, 0, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1251));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1246), null, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1247), 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1249), 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1250), 11 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "ImagePath", "MenuId", "ModifiedDate", "Name", "OrderId", "Price", "Quantity", "Status" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1252), null, null, 14, null, "Kola", null, 30.0, 1, 1 },
                    { 8, 5, new DateTime(2024, 1, 22, 0, 30, 21, 203, DateTimeKind.Local).AddTicks(1253), null, null, 13, null, "Çilekli Milkshake", null, 30.0, 1, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b5d8dfb-c8bd-4a24-9ba3-da6050808d0b");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6040633-db1b-4a48-be54-9f214e77ac9d",
                column: "ConcurrencyStamp",
                value: "c3594a21-0fdf-4a67-b8b0-70215323ab48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c072f0c0-d576-4097-9791-a6937dcba74f", "32728ffc-40f2-48b7-85c8-20c79b30a62f", "Standard User", "STANDARD USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df5a9b38-18e8-48b7-97bf-ad4a9b4afe0e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f812bb76-6180-461c-a33c-1902a3f155d2", "AQAAAAEAACcQAAAAEEQ62vIr7svsYZA9YxDrYwa9x609E4sj7t910KaPDdJ7ddrHZww+D8vXsFaEDGrpvA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImagePath", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5662), "GuncelResimler/patates1.png", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5664), 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5666), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MenuId" },
                values: new object[] { new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5666), 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 19, 52, 51, 813, DateTimeKind.Local).AddTicks(5668));
        }
    }
}
