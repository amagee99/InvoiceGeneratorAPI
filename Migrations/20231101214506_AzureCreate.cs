using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceGeneratorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AzureCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackingNumberCell",
                table: "dbo.InvoiceTemplates",
                newName: "trackingNumberCell");

            migrationBuilder.RenameColumn(
                name: "TemplatePath",
                table: "dbo.InvoiceTemplates",
                newName: "templatePath");

            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "dbo.InvoiceTemplates",
                newName: "templateName");

            migrationBuilder.RenameColumn(
                name: "ShipeeNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "shipeeNameCell");

            migrationBuilder.RenameColumn(
                name: "ShipeeAddressCell",
                table: "dbo.InvoiceTemplates",
                newName: "shipeeAddressCell");

            migrationBuilder.RenameColumn(
                name: "ShipDateCell",
                table: "dbo.InvoiceTemplates",
                newName: "shipDateCell");

            migrationBuilder.RenameColumn(
                name: "ProductTypeCell",
                table: "dbo.InvoiceTemplates",
                newName: "productTypeCell");

            migrationBuilder.RenameColumn(
                name: "PONumCell",
                table: "dbo.InvoiceTemplates",
                newName: "pONumCell");

            migrationBuilder.RenameColumn(
                name: "ItemSizeCell",
                table: "dbo.InvoiceTemplates",
                newName: "itemSizeCell");

            migrationBuilder.RenameColumn(
                name: "ItemQuantityCell",
                table: "dbo.InvoiceTemplates",
                newName: "itemQuantityCell");

            migrationBuilder.RenameColumn(
                name: "ItemPriceTotalCell",
                table: "dbo.InvoiceTemplates",
                newName: "itemPriceTotalCell");

            migrationBuilder.RenameColumn(
                name: "ItemPriceCell",
                table: "dbo.InvoiceTemplates",
                newName: "itemPriceCell");

            migrationBuilder.RenameColumn(
                name: "ItemIdCell",
                table: "dbo.InvoiceTemplates",
                newName: "itemIdCell");

            migrationBuilder.RenameColumn(
                name: "InvoiceTotalCell",
                table: "dbo.InvoiceTemplates",
                newName: "invoiceTotalCell");

            migrationBuilder.RenameColumn(
                name: "InvoiceIdCell",
                table: "dbo.InvoiceTemplates",
                newName: "invoiceIdCell");

            migrationBuilder.RenameColumn(
                name: "InvoiceDateCell",
                table: "dbo.InvoiceTemplates",
                newName: "invoiceDateCell");

            migrationBuilder.RenameColumn(
                name: "CustomerNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "customerNameCell");

            migrationBuilder.RenameColumn(
                name: "CustomerAddressCell",
                table: "dbo.InvoiceTemplates",
                newName: "customerAddressCell");

            migrationBuilder.RenameColumn(
                name: "CompanyPhoneCell",
                table: "dbo.InvoiceTemplates",
                newName: "companyPhoneCell");

            migrationBuilder.RenameColumn(
                name: "CompanyPOBoxCell",
                table: "dbo.InvoiceTemplates",
                newName: "companyPOBoxCell");

            migrationBuilder.RenameColumn(
                name: "CompanyNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "companyNameCell");

            migrationBuilder.RenameColumn(
                name: "CompanyEmailCell",
                table: "dbo.InvoiceTemplates",
                newName: "companyEmailCell");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trackingNumberCell",
                table: "dbo.InvoiceTemplates",
                newName: "TrackingNumberCell");

            migrationBuilder.RenameColumn(
                name: "templatePath",
                table: "dbo.InvoiceTemplates",
                newName: "TemplatePath");

            migrationBuilder.RenameColumn(
                name: "templateName",
                table: "dbo.InvoiceTemplates",
                newName: "TemplateName");

            migrationBuilder.RenameColumn(
                name: "shipeeNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "ShipeeNameCell");

            migrationBuilder.RenameColumn(
                name: "shipeeAddressCell",
                table: "dbo.InvoiceTemplates",
                newName: "ShipeeAddressCell");

            migrationBuilder.RenameColumn(
                name: "shipDateCell",
                table: "dbo.InvoiceTemplates",
                newName: "ShipDateCell");

            migrationBuilder.RenameColumn(
                name: "productTypeCell",
                table: "dbo.InvoiceTemplates",
                newName: "ProductTypeCell");

            migrationBuilder.RenameColumn(
                name: "pONumCell",
                table: "dbo.InvoiceTemplates",
                newName: "PONumCell");

            migrationBuilder.RenameColumn(
                name: "itemSizeCell",
                table: "dbo.InvoiceTemplates",
                newName: "ItemSizeCell");

            migrationBuilder.RenameColumn(
                name: "itemQuantityCell",
                table: "dbo.InvoiceTemplates",
                newName: "ItemQuantityCell");

            migrationBuilder.RenameColumn(
                name: "itemPriceTotalCell",
                table: "dbo.InvoiceTemplates",
                newName: "ItemPriceTotalCell");

            migrationBuilder.RenameColumn(
                name: "itemPriceCell",
                table: "dbo.InvoiceTemplates",
                newName: "ItemPriceCell");

            migrationBuilder.RenameColumn(
                name: "itemIdCell",
                table: "dbo.InvoiceTemplates",
                newName: "ItemIdCell");

            migrationBuilder.RenameColumn(
                name: "invoiceTotalCell",
                table: "dbo.InvoiceTemplates",
                newName: "InvoiceTotalCell");

            migrationBuilder.RenameColumn(
                name: "invoiceIdCell",
                table: "dbo.InvoiceTemplates",
                newName: "InvoiceIdCell");

            migrationBuilder.RenameColumn(
                name: "invoiceDateCell",
                table: "dbo.InvoiceTemplates",
                newName: "InvoiceDateCell");

            migrationBuilder.RenameColumn(
                name: "customerNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "CustomerNameCell");

            migrationBuilder.RenameColumn(
                name: "customerAddressCell",
                table: "dbo.InvoiceTemplates",
                newName: "CustomerAddressCell");

            migrationBuilder.RenameColumn(
                name: "companyPhoneCell",
                table: "dbo.InvoiceTemplates",
                newName: "CompanyPhoneCell");

            migrationBuilder.RenameColumn(
                name: "companyPOBoxCell",
                table: "dbo.InvoiceTemplates",
                newName: "CompanyPOBoxCell");

            migrationBuilder.RenameColumn(
                name: "companyNameCell",
                table: "dbo.InvoiceTemplates",
                newName: "CompanyNameCell");

            migrationBuilder.RenameColumn(
                name: "companyEmailCell",
                table: "dbo.InvoiceTemplates",
                newName: "CompanyEmailCell");
        }
    }
}
