namespace FinalThesis.DAL.DALModels;

public partial class VATPaymentMethod
{
    public int IDVATPaymentMethod { get; set; }
    public string MethodName { get; set; } = null!;
    public virtual ICollection<PartnerTaxDetail> PartnerTaxDetails { get; set; } = [];
}