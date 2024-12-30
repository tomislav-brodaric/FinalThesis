namespace FinalThesis.DAL.DALModels;

public partial class ExemptionBasis
{
    public int IDBasis { get; set; }
    public string BasisName { get; set; } = null!;
    //public virtual ICollection<PDVExemption> PDVExemptions { get; set; } = [];
}
