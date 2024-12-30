namespace FinalThesis.API.BLModels;

public partial class BLOffer
{
    public int IDOffer { get; set; }
    public string OfferName { get; set; } = null!;
    public DateOnly OfferDate { get; set; }
    public int PartnerID { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public decimal? PDV5 { get; set; }
    public decimal? PDV13 { get; set; }
    public decimal? PDV25 { get; set; }
    public DateOnly? ValidUntil { get; set; }
    public int? ExemptionID { get; set; }
    public string? Notes { get; set; }
    public virtual BLPDVExemption? Exemption { get; set; }
    public virtual ICollection<BLOfferProduct> OfferProducts { get; set; } = [];
    public virtual BLPartner Partner { get; set; } = null!;
}