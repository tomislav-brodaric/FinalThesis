namespace FinalThesis.DAL.DALModels;

public partial class Offer
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
    //public virtual PDVExemption? Exemption { get; set; }
    public virtual ICollection<OfferProduct> OfferProducts { get; set; } = [];
    public virtual Partner Partner { get; set; } = null!;
}
