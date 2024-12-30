using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public partial class VMProduct
{
    public int? IDProduct { get; set; }

    [Display(Name = "Product code")]
    public string ProductCode { get; set; } = null!;

    [Display(Name = "Product name")]
    public string ProductName { get; set; } = null!;

    [Display(Name = "Unit of measure")]
    public string? UnitOfMeasure { get; set; }

    [Display(Name = "Additional code")]
    public string? AdditionalCode { get; set; }

    [Display(Name = "Dimensions")]
    public string? Dimensions { get; set; }

    [Display(Name = "Weight (kg)")]
    public decimal? Weight { get; set; } 

    [Display(Name = "Manufacturer")]
    public string? Manufacturer { get; set; }

    [Display(Name = "Product description")]
    public string? ProductDescription { get; set; }

    [Display(Name = "Price")]
    public decimal? Price { get; set; }

    [Display(Name = "Tax number")]
    public int? TaxNumberID { get; set; }

    [Display(Name = "Price with VAT")]
    public decimal? PriceWithVat { get; set; }

    [Display(Name = "Allowance (%)")]
    public decimal? AllowancePercentage { get; set; }

    [Display(Name = "Price in foreign currency")]
    public decimal? PriceInForeignCurrency { get; set; }

    [Display(Name = "Additional price A")]
    public decimal? AdditionalPriceA { get; set; }

    [Display(Name = "Additional price B")]
    public decimal? AdditionalPriceB { get; set; }

    [Display(Name = "Additional price C")]
    public decimal? AdditionalPriceC { get; set; }

    [Display(Name = "Additional price D")]
    public decimal? AdditionalPriceD { get; set; }

    [Display(Name = "Base measurement unit")]
    public string? BaseMeasurementUnit { get; set; }

    [Display(Name = "Index")]
    public decimal? Index { get; set; }

    [Display(Name = "Base unit price (€)")]
    public decimal? BaseUnitPrice { get; set; }

    [Display(Name = "Product group")]
    public int? ProductGroupID { get; set; }

    [Display(Name = "Note")]
    public string? Note { get; set; }

    public virtual VMProductGroup? ProductGroup { get; set; }

    public virtual VMTaxNumber? TaxNumber { get; set; }
}
