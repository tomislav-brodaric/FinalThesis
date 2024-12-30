using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public partial class VMPDVExemption
{
    public int IDExemption { get; set; }

    [Required(ErrorMessage = "Clause code is required.")]
    [DisplayName("Clause Code")]
    public string ClauseCode { get; set; } = null!;

    [Required(ErrorMessage = "Clause name is required.")]
    [DisplayName("Clause Name")]
    public string ClauseName { get; set; } = null!;

    [Required(ErrorMessage = "Basis ID is required.")]
    [DisplayName("Basis")]
    public int BasisID { get; set; }

    [DisplayName("Clause Text")]
    public string? ClauseText { get; set; }

    public virtual VMExemptionBasis? Basis { get; set; }
}