namespace FinalThesis.DAL.DALModels;

public partial class PartnerTaxDetail
{
    public int IDTaxDetail { get; set; }
    public int PartnerID { get; set; }
    public string? TaxID { get; set; }
    public int TaxNumberTypeID { get; set; }
    public int VATPaymentMethodID { get; set; }
    public string? IBAN { get; set; }
    public virtual Partner Partner { get; set; } = null!;
    public virtual TaxNumberType TaxNumberType { get; set; } = null!;
    public virtual VATPaymentMethod VATPaymentMethod { get; set; } = null!;
}