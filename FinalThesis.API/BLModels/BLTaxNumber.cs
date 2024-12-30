using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public partial class BLTaxNumber
{
    public int IDTaxNumber { get; set; }
    public string TaxCode { get; set; } = null!;
    public int TaxRateID { get; set; }
    public decimal TaxRatePercentage { get; set; }

    [JsonIgnore]
    public virtual BLTaxRate? TaxRate { get; set; }

    [JsonIgnore]
    public virtual ICollection<BLProduct> Products { get; set; } = [];

}