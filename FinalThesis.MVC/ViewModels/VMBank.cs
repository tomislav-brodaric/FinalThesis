namespace FinalThesis.MVC.ViewModels;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class VMBank
{
    public int? IDBank { get; set; }

    [Required(ErrorMessage = "Bank name is required.")]
    [StringLength(255, ErrorMessage = "Bank name cannot exceed 255 characters.")]
    [DisplayName("Bank Name")]
    public string BankName { get; set; } = null!;

    [StringLength(255, ErrorMessage = "Bank address cannot exceed 255 characters.")]
    [DisplayName("Bank Address")]
    public string? BankAddress { get; set; }

    [Required(ErrorMessage = "Bank OIB is required.")]
    [StringLength(11, ErrorMessage = "OIB must be 11 digits.")]
    [DisplayName("Bank OIB")]
    public string BankOib { get; set; } = null!;

    [StringLength(34, ErrorMessage = "IBAN cannot exceed 34 characters.")]
    [DisplayName("IBAN")]
    public string? IBAN { get; set; }

    [StringLength(11, ErrorMessage = "SWIFT code cannot exceed 11 characters.")]
    [DisplayName("SWIFT (BIC)")]
    public string? Swift { get; set; }

    public ICollection<VMGiroAccount> GiroAccounts { get; set; } = new List<VMGiroAccount>();

}