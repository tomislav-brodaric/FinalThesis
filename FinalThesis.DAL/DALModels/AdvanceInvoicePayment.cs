namespace FinalThesis.DAL.DALModels;

public partial class AdvanceInvoicePayment
{
    public int IDAdvanceInvoicePayment { get; set; }
    public int AdvanceInvoiceID { get; set; }
    public DateOnly PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public virtual AdvanceInvoice AdvanceInvoice { get; set; } = null!;
}