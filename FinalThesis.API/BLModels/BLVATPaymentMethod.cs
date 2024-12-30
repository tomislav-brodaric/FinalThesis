namespace FinalThesis.API.BLModels;

public class BLVATPaymentMethod
{
    public int IDVATPaymentMethod { get; set; }
    public string MethodName { get; set; } = string.Empty;
    public virtual ICollection<BLPartnerTaxDetail> PartnerTaxDetails { get; set; } = [];
}