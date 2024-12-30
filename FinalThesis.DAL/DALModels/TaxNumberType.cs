namespace FinalThesis.DAL.DALModels;

public partial class TaxNumberType
{
    public int IDTaxNumberType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<PartnerTaxDetail> PartnerTaxDetails { get; set; } = [];
}
