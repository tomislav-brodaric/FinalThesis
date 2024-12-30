using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLPartner
{
    public int IDPartner { get; set; }
    public string PartnerName { get; set; } = string.Empty;
    public int? CountryID { get; set; }
    public int? PartnerTypeID { get; set; }
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
    public string? ParentGLN { get; set; }
    public string? BranchGLN { get; set; }
    public string? BranchCode { get; set; }

    [JsonIgnore]
    public virtual BLCity? BillingCity { get; set; }

    [JsonIgnore]
    public virtual BLCity? City { get; set; }

    [JsonIgnore]
    public virtual BLCountry? Country { get; set; }
    public virtual ICollection<BLPartnerContact> PartnerContacts { get; set; } = [];
    public virtual ICollection<BLPartnerPriceList> PartnerPriceLists { get; set; } = [];
    public virtual ICollection<BLPartnerTaxDetail> PartnerTaxDetails { get; set; } = [];

    [JsonIgnore]
    public virtual BLPartnerType? PartnerType { get; set; }

    public int? ConnectionTypeID { get; set; }
    
    [JsonIgnore]
    public virtual BLConnectionType? ConnectionType { get; set; }
}