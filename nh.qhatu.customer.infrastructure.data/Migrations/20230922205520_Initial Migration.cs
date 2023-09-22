using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nh.qhatu.customer.infrastructure.data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    names = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    last_names = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    id_card_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    credit_card_number = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    credit_card_type_id = table.Column<int>(type: "int", nullable: false),
                    expiration_date = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_payment_method_customer",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_customer_id",
                table: "address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_method_customer_id",
                table: "payment_method",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
