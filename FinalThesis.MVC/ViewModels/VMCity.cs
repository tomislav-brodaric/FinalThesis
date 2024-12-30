using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace FinalThesis.MVC.ViewModels;

public class VMCity
{
    public int? IDCity { get; set; }

    [Required(ErrorMessage = "City name is required.")]
    [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
    [DisplayName("City name")]
    public string CityName { get; set; } = null!;

    [StringLength(5, ErrorMessage = "Tax code cannot exceed 5 characters.")]
    [DisplayName("City tax code")]
    public string? CityTaxCode { get; set; }

    [Range(0, 99.99, ErrorMessage = "Lower tax rate must be between 0 and 99.99.")]
    [DisplayName("Lower tax rate")]
    public decimal? LowerTaxRate { get; set; }

    [Range(0, 99.99, ErrorMessage = "Higher tax rate must be between 0 and 99.99.")]
    [DisplayName("Higher tax rate")]
    public decimal? HigherTaxRate { get; set; }

    [StringLength(34, ErrorMessage = "IBAN cannot exceed 34 characters.")]
    [DisplayName("IBAN for tax")]
    public string? IbanForTax { get; set; }

    [StringLength(10, ErrorMessage = "ZIP code cannot exceed 10 characters.")]
    [DisplayName("Zip code")]
    public string? ZipCode { get; set; }

    [Range(0, 100000, ErrorMessage = "Distance must be a positive number.")]
    [DisplayName("Dist. from HQ")]
    public int? DistanceInKilometres { get; set; }

    [Range(0, 99.99, ErrorMessage = "Local tax rate must be between 0 and 99.99.")]
    [DisplayName("Local tax rate")]
    public decimal? LocalTaxRate { get; set; }

    [Required(ErrorMessage = "Please select a country.")]
    [DisplayName("Country")]
    public int? IDCountry { get; set; }

    public virtual VMCountry? Country { get; set; }

    public string ReturnUrl { get; set; }

    public string DisplayCityTaxCode => string.IsNullOrEmpty(CityTaxCode) ? "N/A" : CityTaxCode;
    public string DisplayLowerTaxRate => LowerTaxRate.HasValue && LowerTaxRate.Value > 0 ? $"{LowerTaxRate:F2} %" : "N/A";
    public string DisplayHigherTaxRate => HigherTaxRate.HasValue && HigherTaxRate.Value > 0 ? $"{HigherTaxRate:F2} %" : "N/A";
    public string DisplayIbanForTax => !string.IsNullOrEmpty(IbanForTax) ? string.Join(" ", Regex.Matches(IbanForTax, ".{1,4}").Cast<Match>().Select(m => m.Value)) : "N/A";
    public string DisplayZipCode => string.IsNullOrEmpty(ZipCode) ? "N/A" : ZipCode;
    public string DisplayDistanceInKilometres => DistanceInKilometres.HasValue && DistanceInKilometres.Value > 0 ? $"{DistanceInKilometres} km" : "N/A";
    public string DisplayLocalTaxRate => LocalTaxRate.HasValue && LocalTaxRate.Value > 0 ? $"{LocalTaxRate:F2} %" : "N/A";
}