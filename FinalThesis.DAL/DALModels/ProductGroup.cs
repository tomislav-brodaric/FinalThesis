namespace FinalThesis.DAL.DALModels;

public partial class ProductGroup
{
    public int IDProductGroup { get; set; }
    public string GroupCode { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public int? ProductTypeID { get; set; }
    public string? Note { get; set; }
    public virtual ProductType? ProductType { get; set; }
    public virtual ICollection<Product> Products { get; set; } = [];
}