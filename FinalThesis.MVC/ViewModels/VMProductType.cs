namespace FinalThesis.MVC.ViewModels;

public partial class VMProductType
{
    public int? IDProductType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<VMProductGroup> ProductGroups { get; set; } = [];
}