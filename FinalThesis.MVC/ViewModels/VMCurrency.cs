using System.ComponentModel;

namespace FinalThesis.MVC.ViewModels;

public class VMCurrency
{
    public int IDCurrency { get; set; }

    [DisplayName("Name")]
    public string? CurrencyName { get; set; }

    [DisplayName("Code")]
    public string CurrencyCode { get; set; } = null!;

    [DisplayName("Symbol")]
    public string? Symbol { get; set; }

    public string? CurrencyNameHr { get; set; }

    public IEnumerable<string>? CountriesUsingCurrency { get; set; }
}
