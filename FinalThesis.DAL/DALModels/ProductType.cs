namespace FinalThesis.DAL.DALModels;

public partial class ProductType
{
    public int IDProductType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<ProductGroup> ProductGroups { get; set; } = [];
}