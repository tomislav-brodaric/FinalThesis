namespace FinalThesis.API.BLModels;

public class BLTaxRate
{
    public int IDTaxRate { get; set; }
    public string TaxRateName { get; set; } = null!;
    public virtual ICollection<BLTaxNumber> TaxNumbers { get; set; } = [];
}