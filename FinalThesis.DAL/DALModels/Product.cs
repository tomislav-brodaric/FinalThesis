namespace FinalThesis.DAL.DALModels;

public partial class Product
{
    public int IDProduct { get; set; }
    public string ProductCode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? UnitOfMeasure { get; set; }
    public string? AdditionalCode { get; set; }
    public string? Dimensions { get; set; }
    public decimal? Weight { get; set; }
    public string? Manufacturer { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? Price { get; set; }
    public int? TaxNumberID { get; set; }
    public decimal? PriceWithVAT { get; set; }
    public decimal? AllowancePercentage { get; set; }
    public decimal? PriceInForeignCurrency { get; set; }
    public decimal? AdditionalPriceA { get; set; }
    public decimal? AdditionalPriceB { get; set; }
    public decimal? AdditionalPriceC { get; set; }
    public decimal? AdditionalPriceD { get; set; }
    public string? BaseMeasurementUnit { get; set; } 
    public decimal? Index { get; set; }
    public decimal? BaseUnitPrice { get; set; }
    public int? ProductGroupID { get; set; }
    public string? Note { get; set; }
    public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } = [];
    public virtual ICollection<OfferProduct> OfferProducts { get; set; } = [];
    public virtual ProductGroup? ProductGroup { get; set; }
    public virtual TaxNumber? TaxNumber { get; set; }
}