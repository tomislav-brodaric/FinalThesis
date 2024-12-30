namespace FinalThesis.DAL.DALModels;

public partial class PriceListType
{
    public int IDPriceListType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<PartnerPriceList> PartnerPriceLists { get; set; } = [];
}
