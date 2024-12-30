namespace FinalThesis.DAL.DALModels;

public partial class Partner
{
    public int IDPartner { get; set; }
    public string PartnerName { get; set; } = null!;
    public int? CountryID { get; set; }
    public int PartnerTypeID { get; set; }
    public string? Note { get; set; }
    public int? CityID { get; set; }
    public string? AddressStreet { get; set; }
    public string? AddressNumber { get; set; }
    public int? BillingCityID { get; set; }
    public string? BillingStreet { get; set; }
    public string? BillingNumber { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? WebAddress { get; set; }
    public string? ParentGln { get; set; }
    public string? BranchGln { get; set; }
    public string? BranchCode { get; set; }
    public int? ConnectionTypeID { get; set; }
    public virtual ICollection<AdvanceInvoice> AdvanceInvoices { get; set; } = [];
    public virtual City? BillingCity { get; set; }
    public virtual ConnectionType? ConnectionType { get; set; }
    public virtual Country? Country { get; set; }
    public virtual City? City { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; } = [];
    public virtual ICollection<Offer> Offers { get; set; } = [];
    public virtual ICollection<PartnerContact> PartnerContacts { get; set; } = [];
    public virtual ICollection<PartnerPriceList> PartnerPriceLists { get; set; } = [];
    public virtual ICollection<PartnerTaxDetail> PartnerTaxDetails { get; set; } = [];
    public virtual PartnerType PartnerType { get; set; } = null!;
}