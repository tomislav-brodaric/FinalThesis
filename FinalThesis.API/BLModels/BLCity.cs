using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLCity
{
    public int IDCity { get; set; }
    public string CityName { get; set; } = string.Empty;
    public string? CityTaxCode { get; set; }
    public decimal? LowerTaxRate { get; set; }
    public decimal? HigherTaxRate { get; set; }
    public string? IBANForTax { get; set; }
    public string? ZipCode { get; set; }
    public int? DistanceInKilometres { get; set; }
    public decimal? LocalTaxRate { get; set; }
    public int? IDCountry { get; set; }

    [JsonIgnore]
    public virtual BLCountry? Country { get; set; }

    [JsonIgnore]
    public virtual ICollection<BLPartner> PartnerBillingCities { get; set; } = [];

    [JsonIgnore]
    public virtual ICollection<BLPartner> PartnerCities { get; set; } = [];
}