namespace FinalThesis.DAL.DALModels;

public partial class ConnectionType
{
    public int IDConnectionType { get; set; }
    public string ConnectionName { get; set; } = null!;
    public virtual ICollection<Partner> Partners { get; set; } = [];
}
