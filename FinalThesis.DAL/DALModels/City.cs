namespace FinalThesis.DAL.DALModels;

public partial class City
{
    public int IDCity { get; set; }
    public string CityName { get; set; } = null!;
    public string? CityTaxCode { get; set; }
    public decimal? LowerTaxRate { get; set; }
    public decimal? HigherTaxRate { get; set; }
    public string? IBANForTax { get; set; }
    public string? ZipCode { get; set; }
    public int? DistanceInKilometres { get; set; }
    public decimal? LocalTaxRate { get; set; }
    public int? IDCountry { get; set; }
    public virtual Country? Country { get; set; }
    public virtual ICollection<Partner> PartnerBillingCities { get; set; } = [];
    public virtual ICollection<Partner> PartnerCities { get; set; } = [];
}
