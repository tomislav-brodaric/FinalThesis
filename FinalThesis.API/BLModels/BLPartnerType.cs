namespace FinalThesis.API.BLModels;

public class BLPartnerType
{
    public int IDPartnerType { get; set; }
    public string TypeName { get; set; } = null!;
    public virtual ICollection<BLPartner> Partners { get; set; } = [];
}