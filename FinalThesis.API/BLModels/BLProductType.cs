namespace FinalThesis.API.BLModels;

public class BLProductType
{
    public int IDProductType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<BLProductGroup> ProductGroups { get; set; } = [];
}
