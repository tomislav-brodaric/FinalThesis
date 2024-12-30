namespace FinalThesis.DAL.DALModels;

public partial class TaxRate
{
    public int IDTaxRate { get; set; }
    public string TaxRateName { get; set; } = null!;
    public virtual ICollection<TaxNumber> TaxNumbers { get; set; } = [];
}