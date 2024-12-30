using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public class VMInvoice
{
    public int? IDInvoice { get; set; }

    [DisplayName("Invoice number")]
    public string InvoiceNumber { get; set; } = string.Empty;

    [DisplayName("Invoice date")]
    [DataType(DataType.Date)]
    public DateOnly InvoiceDate { get; set; }

    [DisplayName("Delivery note number")]
    public string? DeliveryNoteNumber { get; set; }

    [DisplayName("Delivery date")]
    [DataType(DataType.Date)]
    public DateOnly? DeliveryDate { get; set; }

    [DisplayName("Due date")]
    [DataType(DataType.Date)]
    public DateOnly? DueDate { get; set; }

    [DisplayName("Order number")]
    public string? OrderNumber { get; set; }

    [DisplayName("Order date")]
    [DataType(DataType.Date)]
    public DateOnly? OrderDate { get; set; }

    [DisplayName("Invoice amount (€)")]
    public decimal? InvoiceAmount { get; set; }

    [DisplayName("Partner")]
    public int PartnerID { get; set; }

    [DisplayName("Partner mame")]
    public string? PartnerName { get; set; }

    [DisplayName("Notes")]
    public string? Notes { get; set; }

    [DisplayName("Posting description")]
    public string? PostingDescription { get; set; }

    public virtual ICollection<VMInvoiceProduct> InvoiceProducts { get; set; } = [];
}