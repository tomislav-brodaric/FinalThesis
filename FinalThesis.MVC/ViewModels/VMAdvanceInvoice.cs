using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels
{
    public class VMAdvanceInvoice
    {
        public int? IDAdvanceInvoice { get; set; }

        [DisplayName("Advance Invoice Number")]
        public string AdvanceInvoiceNumber { get; set; } = string.Empty;

        [DisplayName("Advance Invoice Date")]
        [DataType(DataType.Date)]
        public DateOnly AdvanceInvoiceDate { get; set; }

        [DisplayName("Partner")]
        public int PartnerID { get; set; }
        public VMPartner Partner { get; set; } = new VMPartner();

        [DisplayName("Purpose Description")]
        public string? PurposeDescription { get; set; }

        [DisplayName("Invoice Amount (€)")]
        public decimal? InvoiceAmount { get; set; }

        [DisplayName("Transitional Item (€)")]
        [DataType(DataType.Currency)]
        public decimal? TransitionalItem { get; set; }

        [DisplayName("Exempt From VAT (€)")]
        [DataType(DataType.Currency)]
        public decimal? ExemptFromVAT { get; set; }

        [DisplayName("Base 0%")]
        public decimal? Base0 { get; set; }

        [DisplayName("Base 5%")]
        public decimal? Base5 { get; set; }

        [DisplayName("PDV 5%")]
        public decimal? PDV5 { get; set; }

        [DisplayName("Base 13%")]
        public decimal? Base13 { get; set; }

        [DisplayName("PDV 13%")]
        public decimal? PDV13 { get; set; }

        [DisplayName("Base 25%")]
        public decimal? Base25 { get; set; }

        [DisplayName("PDV 25%")]
        public decimal? PDV25 { get; set; }

        [DisplayName("Exemption ID")]
        public int? ExemptionID { get; set; }

        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DisplayName("Posting Description")]
        public string? PostingDescription { get; set; }

        public virtual ICollection<VMAdvanceInvoicePayment> AdvanceInvoicePayments { get; set; } = new List<VMAdvanceInvoicePayment>();
    }
}
