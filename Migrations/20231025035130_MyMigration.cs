using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGeneratorAPI.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.InvoiceTemplates",
                columns: table => new
                {
                    TemplateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplatePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceIdCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDateCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNameCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPOBoxCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmailCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhoneCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddressCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNameCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipeeAddressCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipeeNameCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONumCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipDateCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemIdCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantityCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSizeCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPriceCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPriceTotalCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTotalCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumberCell = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.InvoiceTemplates", x => x.TemplateID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo.InvoiceTemplates");
        }
    }
}
