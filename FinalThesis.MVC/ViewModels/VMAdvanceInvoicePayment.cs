using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public class VMAdvanceInvoicePayment
{
    public int IDAdvanceInvoicePayment { get; set; }

    [DisplayName("Payment Date")]
    [DataType(DataType.Date)]
    public DateOnly PaymentDate { get; set; }

    [DisplayName("Amount (€)")]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }
}
