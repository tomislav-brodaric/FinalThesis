namespace FinalThesis.DAL.DALModels;

public partial class PartnerPriceList
{
    public int IDPriceList { get; set; }
    public int PartnerID { get; set; }
    public int PriceListTypeID { get; set; }
    public decimal? Discount { get; set; }
    public int? PaymentTerms { get; set; }
    public virtual Partner Partner { get; set; } = null!;
    public virtual PriceListType PriceListType { get; set; } = null!;
}
