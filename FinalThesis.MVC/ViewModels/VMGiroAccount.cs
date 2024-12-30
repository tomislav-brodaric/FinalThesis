using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FinalThesis.MVC.ViewModels;

public class VMGiroAccount
{
    public int? IDGiroAccount { get; set; }

    [Required(ErrorMessage = "Account name is required.")]
    [DisplayName("Account Name")]
    public string AccountName { get; set; } = null!;

    [Required(ErrorMessage = "IBAN is required.")]
    [StringLength(34, ErrorMessage = "IBAN cannot exceed 34 characters.")]
    [DisplayName("IBAN")]
    public string Iban { get; set; } = null!;

    [DisplayName("Bank")]
    public int? IDBank { get; set; }

    public VMBank? Bank { get; set; }

    public string? ReturnUrl { get; set; }

    public string DisplayIban => string.IsNullOrEmpty(Iban) ? string.Empty : string.Join(" ", Regex.Matches(Iban, ".{1,4}").Cast<Match>().Select(m => m.Value));
}
