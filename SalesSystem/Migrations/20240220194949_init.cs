using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmeenStock = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePruchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuentityStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pruchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Pay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pruchases_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pruchases_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    TypeClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_TypeClients_TypeClientId",
                        column: x => x.TypeClientId,
                        principalTable: "TypeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTemp",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quentit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                 AfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTemp", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceTemp_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                }) ;

            migrationBuilder.CreateTable(
                name: "PruchaseDetails",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PruchaseId = table.Column<int>(type: "int", nullable: false),
                    Quentiti = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PruchaseDetails", x => new { x.ProductId, x.PruchaseId });
                    table.ForeignKey(
                        name: "FK_PruchaseDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PruchaseDetails_Pruchases_PruchaseId",
                        column: x => x.PruchaseId,
                        principalTable: "Pruchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Pay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Disount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                 AfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quentit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Descreption", "Name" },
                values: new object[,]
                {
                    { 1, null, "لحوم" },
                    { 2, null, "خضار" },
                    { 3, null, "فواكه" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Address", "AmeenStock", "NameStock", "Phone" },
                values: new object[,]
                {
                    { 1, null, null, "رئيسي", null },
                    { 2, null, null, "فرعي", null }
                });

            migrationBuilder.InsertData(
                table: "TypeClients",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, null, "شركه" },
                    { 2, null, "تاجر جمله" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeClientId",
                table: "Clients",
                column: "TypeClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemp_ProductId",
                table: "InvoiceTemp",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockId",
                table: "Orders",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockId",
                table: "Products",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_PruchaseDetails_PruchaseId",
                table: "PruchaseDetails",
                column: "PruchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pruchases_ResourceId",
                table: "Pruchases",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pruchases_StockId",
                table: "Pruchases",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceTemp");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PruchaseDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Pruchases");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "TypeClients");
        }
    }
}
