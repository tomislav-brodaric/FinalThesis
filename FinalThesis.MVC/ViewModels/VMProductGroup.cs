namespace FinalThesis.MVC.ViewModels;

public partial class VMProductGroup
{
    public int? IDProductGroup { get; set; }
    public string GroupCode { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public int? ProductTypeID { get; set; }
    public string? Note { get; set; }
    public virtual VMProductType? ProductType { get; set; }
    public virtual ICollection<VMProduct> Products { get; set; } = [];
}