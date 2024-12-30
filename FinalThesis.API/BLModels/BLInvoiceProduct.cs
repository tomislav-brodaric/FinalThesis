namespace FinalThesis.API.BLModels;

public class BLInvoiceProduct
{
    public int IDInvoiceProduct { get; set; }
    public int InvoiceID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal? Total { get; set; }
    public virtual BLInvoice Invoice { get; set; } = null!;
    public virtual BLProduct Product { get; set; } = null!;
}
