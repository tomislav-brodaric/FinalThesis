namespace FinalThesis.API.BLModels;

public partial class BLAdvanceInvoicePayment
{
    public int IDAdvanceInvoicePayment { get; set; }
    public int AdvanceInvoiceID { get; set; }
    public DateOnly PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public virtual BLAdvanceInvoice AdvanceInvoice { get; set; } = null!;
}