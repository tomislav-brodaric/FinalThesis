using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLCountry
{
    public int IDCountry { get; set; }
    public string ShortNameHr { get; set; } = null!;
    public string? OfficialNameHr { get; set; }
    public string ShortNameEn { get; set; } = null!;
    public string? OfficialNameEn { get; set; }
    public string TwoLetterCode { get; set; } = null!;
    public string ThreeLetterCode { get; set; } = null!;
    public int NumericCode { get; set; }
    public string? Note { get; set; }
    public bool? IsEUMember { get; set; }
    public int? CurrencyID { get; set; }

    [JsonIgnore]
    public virtual ICollection<BLCity> Cities { get; set; } = [];

    [JsonIgnore]
    public virtual BLCurrency? Currency { get; set; }

    [JsonIgnore]
    public virtual ICollection<BLPartner> Partners { get; set; } = [];

}