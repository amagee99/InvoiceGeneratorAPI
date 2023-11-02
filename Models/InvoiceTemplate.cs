
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceGeneratorAPI.Models
{
    [Table("dbo.InvoiceTemplates")]
    public class InvoiceTemplate
    {
        //references invoice template (will likely autogenerate)
        [Column("TemplateID")]
        public long id { get; set; }
        //references invoice template for the user
        public string templateName { get; set; }
        public string templatePath { get; set; }

    //data to cell mapping
        //invoice referencing
        public string? invoiceIdCell { get; set; }
        public string? invoiceDateCell { get; set; }

        //Header cell Info
        public string? companyNameCell { get; set; }
        public string? companyPOBoxCell { get; set; }
        public string? companyEmailCell { get; set; }
        public string? companyPhoneCell { get; set; }

        //Customer cell Info
        public string? customerAddressCell { get; set; }
        public string? customerNameCell { get; set; }

        //Shippee cell Info
        public string? shipeeAddressCell { get; set; }
        public string? shipeeNameCell { get; set; }

        //Order cell Info
        public string? pONumCell { get; set; }
        public string? shipDateCell { get; set; }
        public string? productTypeCell { get; set; }

        //Item cell Info (will need to create multiple items)
        public string? itemIdCell { get; set; }
        public string? itemQuantityCell { get; set; }
        public string? itemSizeCell { get; set; }
        public string? itemPriceCell { get; set; }
        public string? itemPriceTotalCell { get; set; }

        //Invoice Total
        public string? invoiceTotalCell { get; set; }

        //Tracking cell Info
        public string? trackingNumberCell { get; set; }

    }
}
