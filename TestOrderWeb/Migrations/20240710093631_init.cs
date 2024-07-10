using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrderWeb.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SenderAddres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RecipientCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RecipientAddres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CargoWeight = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DateCargoPickup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllOrders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllOrders");
        }
    }
}
