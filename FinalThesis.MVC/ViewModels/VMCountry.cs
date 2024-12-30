using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public class VMCountry
{
    public int? IDCountry { get; set; }

    [Required(ErrorMessage = "Short country name is required.")]
    [DisplayName("Short name")]
    public string ShortNameHr { get; set; } = null!;

    [DisplayName("Official name")]
    public string? OfficialNameHr { get; set; }

    [Required(ErrorMessage = "Short country name (ENG) is required.")]
    [DisplayName("Short name (ENG)")]
    public string ShortNameEn { get; set; } = null!;

    [DisplayName("Official name (ENG)")]
    public string? OfficialNameEn { get; set; }

    [Required(ErrorMessage = "Two letters code is required.")]
    [DisplayName("Two letters code")]
    public string TwoLetterCode { get; set; } = null!;

    [Required(ErrorMessage = "Three letters code is required.")]
    [DisplayName("Three letters code")]
    public string ThreeLetterCode { get; set; } = null!;

    [DisplayName("Numeric code")]
    public int NumericCode { get; set; }

    [DisplayName("Note")]
    public string? Note { get; set; }

    [DisplayName("EU")]
    public bool IsEUmember { get; set; }

    public virtual ICollection<VMCity> Cities { get; set; } = [];

    [DisplayName("Currency")]
    public string? CurrencyName { get; set; }

    public string DisplayOfficialNameHr => string.IsNullOrEmpty(OfficialNameHr) ? "N/A" : OfficialNameHr;
    public string DisplayOfficialNameEn => string.IsNullOrEmpty(OfficialNameEn) ? "N/A" : OfficialNameEn;
    public string DisplayNote => string.IsNullOrEmpty(Note) ? "N/A" : Note;
}