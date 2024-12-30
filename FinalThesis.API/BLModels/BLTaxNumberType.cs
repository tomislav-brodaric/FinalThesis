namespace FinalThesis.API.BLModels;

public class BLTaxNumberType
{
    public int IDTaxNumberType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<BLPartnerTaxDetail> PartnerTaxDetails { get; set; } = [];
}