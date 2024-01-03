using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class dbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    MaSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.MaSP);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    MaDH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.MaDH);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_MaKH",
                        column: x => x.MaKH,
                        principalTable: "Customers",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    MaDH = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.MaDH, x.MaSP });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_MaDH",
                        column: x => x.MaDH,
                        principalTable: "Orders",
                        principalColumn: "MaDH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_MaSP",
                        column: x => x.MaSP,
                        principalTable: "Products",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_MaSP",
                table: "OrderDetail",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MaKH",
                table: "Orders",
                column: "MaKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
