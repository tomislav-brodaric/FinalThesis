namespace FinalThesis.API.BLModels;

public class BLPriceListType
{
    public int IDPriceListType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<BLPartnerPriceList> PartnerPriceLists { get; set; } = [];
}