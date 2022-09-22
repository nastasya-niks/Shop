using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class ShopCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopCarItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carid = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShopCarID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCarItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopCarItem_Car_Carid",
                        column: x => x.Carid,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopCarItem_Carid",
                table: "shopCarItem",
                column: "Carid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopCarItem");
        }
    }
}
