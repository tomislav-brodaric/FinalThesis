namespace FinalThesis.DAL.DALModels;

public partial class GiroAccount
{
    public int IDGiroAccount { get; set; }
    public string AccountName { get; set; } = null!;
    public string IBAN { get; set; } = null!;
    public int? BankID { get; set; }
    public virtual Bank? Bank { get; set; }
}