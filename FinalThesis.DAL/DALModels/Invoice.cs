namespace FinalThesis.DAL.DALModels;

public partial class Invoice
{
    public int IDInvoice { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateOnly InvoiceDate { get; set; }
    public int PartnerID { get; set; }
    public string? DeliveryNoteNumber { get; set; }
    public DateOnly? DeliveryDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public string? OrderNumber { get; set; }
    public DateOnly? OrderDate { get; set; }
    public decimal? InvoiceAmount { get; set; }
    public decimal? TransitionalItem { get; set; }
    public decimal? ExemptFromVAT { get; set; }
    public decimal? Base0 { get; set; }
    public decimal? Base5 { get; set; }
    public decimal? PDV5 { get; set; }
    public decimal? Base13 { get; set; }
    public decimal? PDV13 { get; set; }
    public decimal? Base25 { get; set; }
    public decimal? PDV25 { get; set; }
    public int? ExemptionID { get; set; }
    public string? Notes { get; set; }
    public string? PostingDescription { get; set; }
    //public virtual PDVExemption? Exemption { get; set; }
    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    public virtual Partner Partner { get; set; } = null!;
}