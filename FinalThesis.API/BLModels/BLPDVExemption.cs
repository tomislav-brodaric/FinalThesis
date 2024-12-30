namespace FinalThesis.API.BLModels;

public partial class BLPDVExemption
{
    public int IDExemption { get; set; }
    public string ClauseCode { get; set; } = null!;
    public string ClauseName { get; set; } = null!;
    public int BasisID { get; set; }
    public string? ClauseText { get; set; }
    public virtual BLExemptionBasis? Basis { get; set; }
}