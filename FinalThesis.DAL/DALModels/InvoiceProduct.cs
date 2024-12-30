namespace FinalThesis.DAL.DALModels;

public partial class InvoiceProduct
{
    public int IDInvoiceProduct { get; set; }
    public int InvoiceID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal? Total { get; set; }
    public virtual Invoice Invoice { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}