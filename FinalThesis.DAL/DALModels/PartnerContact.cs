namespace FinalThesis.DAL.DALModels;

public partial class PartnerContact
{
    public int IDContact { get; set; }
    public int PartnerID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Department { get; set; }
    public string? Position { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public virtual Partner Partner { get; set; } = null!;
}