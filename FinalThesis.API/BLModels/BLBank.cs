using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLBank
{
    public int IDBank { get; set; }
    public string BankName { get; set; } = null!;
    public string? BankAddress { get; set; }
    public string BankOIB { get; set; } = null!;
    public string? IBAN { get; set; }
    public string? SWIFT { get; set; }

    [JsonIgnore]
    public virtual ICollection<BLGiroAccount> GiroAccounts { get; set; } = [];
}