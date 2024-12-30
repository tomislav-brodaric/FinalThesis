namespace FinalThesis.DAL.DALModels;

public partial class PartnerType
{
    public int IDPartnerType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<Partner> Partners { get; set; } = [];
}
