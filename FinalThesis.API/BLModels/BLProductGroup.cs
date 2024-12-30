namespace FinalThesis.API.BLModels;

public class BLProductGroup
{
    public int IDProductGroup { get; set; }
    public string GroupCode { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public int? ProductTypeID { get; set; }
    public string? Note { get; set; }
    public virtual BLProductType? ProductType { get; set; }
    public virtual ICollection<BLProduct> Products { get; set; } = [];
}
