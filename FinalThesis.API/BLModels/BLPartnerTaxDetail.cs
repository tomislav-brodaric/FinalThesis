using System.Text.Json.Serialization;

namespace FinalThesis.API.BLModels;

public class BLPartnerTaxDetail
{
    public int IDTaxDetail { get; set; }
    public int PartnerID { get; set; }
    public string? TaxID { get; set; }
    public int TaxNumberTypeID { get; set; }
    public int VATPaymentMethodID { get; set; }
    public string? IBAN { get; set; }

    [JsonIgnore]
    public virtual BLPartner? Partner { get; set; }

    [JsonIgnore]
    public virtual BLTaxNumberType? TaxNumberType { get; set; }

    [JsonIgnore]
    public virtual BLVATPaymentMethod? VATPaymentMethod { get; set; }
}