using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public class VMTaxRate
{
    public int IDTaxRate { get; set; }

    [Required(ErrorMessage = "Tax rate name is required.")]
    [DisplayName("Tax rate name")]
    public string TaxRateName { get; set; } = null!;

    public virtual ICollection<VMTaxNumber> TaxNumbers { get; set; } = [];
}