namespace FinalThesis.DAL.DALModels;

public partial class TaxNumber
{
    public int IDTaxNumber { get; set; }
    public string TaxCode { get; set; } = null!;
    public int TaxRateID { get; set; }
    public decimal TaxRatePercentage { get; set; }
    public virtual ICollection<Product> Products { get; set; } = [];
    public virtual TaxRate TaxRate { get; set; } = null!;
}