namespace FinalThesis.DAL.DALModels;

public partial class Bank
{
    public int IDBank { get; set; }
    public string BankName { get; set; } = null!;
    public string? BankAddress { get; set; }
    public string BankOIB { get; set; } = null!;
    public string? IBAN { get; set; }
    public string? Swift { get; set; }
    public virtual ICollection<GiroAccount> GiroAccounts { get; set; } = [];
}