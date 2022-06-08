using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketFormation.Persitence.Migrations
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
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Unit_price = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Article_number = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCart_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Fill_start_time = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Fill_end_time = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Total_without_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Total_with_discount = table.Column<decimal>(type: "numeric", nullable: false),
                    AccountID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCart_ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartContents",
                columns: table => new
                {
                    CartContents_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Discount_price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price_incl_quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Item_number_in_cart = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    ShoppingCartID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartContents", x => x.CartContents_ID);
                    table.ForeignKey(
                        name: "FK_CartContents_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartContents_ShoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCart_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Account_ID", "Username" },
                values: new object[,]
                {
                    { new Guid("c370b962-0eb5-404c-b3d6-8373b79feb92"), "Владимир" },
                    { new Guid("817d8895-4a86-4d83-9cab-44c6adda1e99"), "Евгений" },
                    { new Guid("df52bca9-3e33-489e-8ce5-cd665c163589"), "Екатерина" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "Article_number", "Name", "Unit_price" },
                values: new object[,]
                {
                    { new Guid("730b2a39-cb74-4eb0-ab90-43de3970caae"), "54356375673", "Сывороточный напиток. Мажитэль ананас манго", 45.60m },
                    { new Guid("f35200f7-bd6c-4110-b3d3-72f6378634a8"), "988797345", "Йогурт. Активиа чернослив", 78.90m },
                    { new Guid("4eea67a3-9b8c-47a5-b19c-5dac727d7cab"), "56756867", "Йогурт. Активиа киви и мюсли", 79.45m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartContents_ProductID",
                table: "CartContents",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartContents_ShoppingCartID",
                table: "CartContents",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AccountID",
                table: "ShoppingCarts",
                column: "AccountID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartContents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
