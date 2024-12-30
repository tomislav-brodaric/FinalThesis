namespace FinalThesis.API.BLModels;

public class BLCurrency
{
    public int IDCurrency { get; set; }
    public string? CurrencyName { get; set; }
    public string CurrencyCode { get; set; } = null!;
    public string? Symbol { get; set; }
    public string? CurrencyNameHr { get; set; }
    public virtual ICollection<BLCountry> Countries { get; set; } = [];
}