using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nh.qhatu.omnichannel.infrastructure.data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    customer_id = table.Column<string>(type: "longtext", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    customer_id = table.Column<string>(type: "longtext", nullable: false),
                    payment_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_payment",
                        column: x => x.payment_id,
                        principalTable: "payment",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    order_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    product_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_order_detail_order",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_order_payment_id",
                table: "order",
                column: "payment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "payment");
        }
    }
}
