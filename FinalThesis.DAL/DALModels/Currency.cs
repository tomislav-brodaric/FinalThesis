namespace FinalThesis.DAL.DALModels;

public partial class Currency
{
    public int IDCurrency { get; set; }
    public string? CurrencyName { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public string? Symbol { get; set; }
    public string? CurrencyNameHr { get; set; }
    public virtual ICollection<Country> Countries { get; set; } = [];
}