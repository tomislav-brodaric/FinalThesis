
using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLPartnerPriceList
{
    public int IDPriceList { get; set; }
    public int PartnerID { get; set; }
    public int PriceListTypeID { get; set; }
    public decimal? Discount { get; set; }
    public int? PaymentTerms { get; set; }

    [JsonIgnore]
    public virtual BLPartner? Partner { get; set; }

    [JsonIgnore]
    public virtual BLPriceListType? PriceListType { get; set; } 
}