namespace FinalThesis.DAL.DALModels;

public partial class Country
{
    public int IDCountry { get; set; }
    public string ShortNameHr { get; set; } = null!;
    public string? OfficialNameHr { get; set; }
    public string ShortNameEn { get; set; } = null!;
    public string? OfficialNameEn { get; set; }
    public string TwoLetterCode { get; set; } = null!;
    public string ThreeLetterCode { get; set; } = null!;
    public int NumericCode { get; set; }
    public string? Note { get; set; }
    public bool? IsEUMember { get; set; }
    public int? CurrencyID { get; set; }
    public virtual Currency? Currency { get; set; }
    public virtual ICollection<City> Cities { get; set; } = [];
    public virtual ICollection<Partner> Partners { get; set; } = [];
}