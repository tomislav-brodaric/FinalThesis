using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public partial class VMTaxNumber
{
    public int IDTaxNumber { get; set; }

    [Required(ErrorMessage = "Tax code is required.")]
    [DisplayName("Tax Code")]
    public string TaxCode { get; set; } = null!;

    [Required(ErrorMessage = "Tax rate ID is required.")]
    [DisplayName("Tax rate")]
    public int TaxRateID { get; set; }

    [Range(0, 100, ErrorMessage = "Tax rate percentage must be between 0 and 100.")]
    [DisplayName("Tax rate percentage")]
    public decimal TaxRatePercentage { get; set; }

    public virtual VMTaxRate? TaxRate { get; set; }
}