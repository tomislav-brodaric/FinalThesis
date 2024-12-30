namespace FinalThesis.DAL.DALModels;

public partial class AdvanceInvoice
{
    public int IDAdvanceInvoice { get; set; }
    public string AdvanceInvoiceNumber { get; set; } = null!;
    public DateOnly AdvanceInvoiceDate { get; set; }
    public int PartnerID { get; set; }
    public string? PurposeDescription { get; set; }
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
    public virtual ICollection<AdvanceInvoicePayment> AdvanceInvoicePayments { get; set; } = [];
    //public virtual PDVExemption? Exemption { get; set; }
    public virtual Partner Partner { get; set; } = null!;
}