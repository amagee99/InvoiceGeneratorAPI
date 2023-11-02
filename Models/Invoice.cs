namespace InvoiceGeneratorAPI.Models
{
    public class Invoice
    {
        //Invoice Info
        public long id { get; set; }
        public long invoiceDate { get; set; }

        //Header Info
        public string? companyName { get; set; }
        public string? companyPOBox { get; set; }
        public string? companyEmail { get; set; }
        public string? companyPhone { get; set; }

        //Customer Info
        public string? customerAddress { get; set; }
        public string? customerName{ get; set; }

        //Shippee Info
        public string?shipeeAddress { get; set; }
        public string? shipeeName { get; set; }

        //Order Info
        public long pONum { get; set; }
        public long shipDate { get; set; }
        public string? productType { get; set; }

        //Item Info
        public long itemId { get; set; }
        public int itemQuantity { get; set; }
        public long itemSize { get; set; }
        public float itemPrice { get; set; }

        //Tracking Info
        public long trackingNumber { get; set; }




    }
}
