using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLPartnerContact
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

    [JsonIgnore]
    public virtual BLPartner? Partner { get; set; }
}