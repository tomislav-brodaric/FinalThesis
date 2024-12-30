namespace FinalThesis.API.BLModels;

public class BLGiroAccount
{
    public int IDGiroAccount { get; set; }
    public string AccountName { get; set; } = null!;
    public int? IDBank { get; set; }
    public string IBAN { get; set; } = null!;
    public virtual BLBank? Bank { get; set; }
}