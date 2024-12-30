using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public partial class BLExemptionBasis
{
    public int IDBasis { get; set; }
    public string BasisName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<BLPDVExemption> PDVExemptions { get; set; } = [];
}