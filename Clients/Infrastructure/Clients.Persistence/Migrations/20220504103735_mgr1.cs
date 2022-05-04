using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clients.Persistence.Migrations
{
    public partial class mgr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Date_of_Birth = table.Column<DateTime>(type: "date", nullable: false),
                    Phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    Device_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Screen_resolution_height = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Screen_resolution_width = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevices", x => x.Device_ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountUserDevice",
                columns: table => new
                {
                    AccountsAccount_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserDevicesDevice_ID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserDevice", x => new { x.AccountsAccount_ID, x.UserDevicesDevice_ID });
                    table.ForeignKey(
                        name: "FK_AccountUserDevice_Accounts_AccountsAccount_ID",
                        column: x => x.AccountsAccount_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountUserDevice_UserDevices_UserDevicesDevice_ID",
                        column: x => x.UserDevicesDevice_ID,
                        principalTable: "UserDevices",
                        principalColumn: "Device_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Account_ID", "Date_of_Birth", "Email", "Phone_number", "Username" },
                values: new object[,]
                {
                    { new Guid("c370b962-0eb5-404c-b3d6-8373b79feb92"), new DateTime(1987, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "vladimiR@mail.ru", "89763547685", "Владимир" },
                    { new Guid("817d8895-4a86-4d83-9cab-44c6adda1e99"), new DateTime(1990, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "zhenya@mail.ru", "89981329864", "Евгений" },
                    { new Guid("df52bca9-3e33-489e-8ce5-cd665c163589"), new DateTime(1995, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "katty@mail.ru", "89807432312", "Екатерина" }
                });

            migrationBuilder.InsertData(
                table: "UserDevices",
                columns: new[] { "Device_ID", "Brand", "Model", "Screen_resolution_height", "Screen_resolution_width" },
                values: new object[,]
                {
                    { new Guid("bfd88510-b501-411d-a7d0-6bc6c2a77956"), "Huawei", "P50 Pro", 2700, 1228 },
                    { new Guid("581be8ec-e28e-4085-92f5-072ebc28ae58"), "Samsung", "Galaxy S21", 2400, 1080 },
                    { new Guid("501edfcc-641d-4343-8a5c-c46b817a2980"), "Xiaomi", "Mi 11 Lite", 2400, 1080 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserDevice_UserDevicesDevice_ID",
                table: "AccountUserDevice",
                column: "UserDevicesDevice_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUserDevice");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "UserDevices");
        }
    }
}
