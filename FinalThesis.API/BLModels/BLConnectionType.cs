namespace FinalThesis.API.BLModels;

public class BLConnectionType
{
    public int IDConnectionType { get; set; }
    public string ConnectionName { get; set; } = null!;
    public virtual ICollection<BLPartner> Partners { get; set; } = [];
}