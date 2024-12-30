using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public partial class VMExemptionBasis
{
    public int IDBasis { get; set; }

    [Required(ErrorMessage = "Basis name is required")]
    [DisplayName("Basis name")]
    public string BasisName { get; set; } = null!;

    public virtual ICollection<VMPDVExemption> PDVExemptions { get; set; } = [];
}
