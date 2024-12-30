using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.DALModels;

public partial class FinalThesisContext : DbContext
{
    public FinalThesisContext()
    {
    }

    public FinalThesisContext(DbContextOptions<FinalThesisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdvanceInvoice> AdvanceInvoices { get; set; }
    public virtual DbSet<AdvanceInvoicePayment> AdvanceInvoicePayments { get; set; }
    public virtual DbSet<Bank> Banks { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<ConnectionType> ConnectionTypes { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<ExemptionBasis> ExemptionBases { get; set; }
    public virtual DbSet<GiroAccount> GiroAccounts { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<InvoiceProduct> InvoiceProducts { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<OfferProduct> OfferProducts { get; set; }
    public virtual DbSet<Partner> Partners { get; set; }
    public virtual DbSet<PartnerContact> PartnerContacts { get; set; }
    public virtual DbSet<PartnerPriceList> PartnerPriceLists { get; set; }
    public virtual DbSet<PartnerTaxDetail> PartnerTaxDetails { get; set; }
    public virtual DbSet<PartnerType> PartnerTypes { get; set; }
    //public virtual DbSet<PDVExemption> PDVExemptions { get; set; }
    public virtual DbSet<PriceListType> PriceListTypes { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductGroup> ProductGroups { get; set; }
    public virtual DbSet<ProductType> ProductTypes { get; set; }
    public virtual DbSet<TaxNumber> TaxNumbers { get; set; }
    public virtual DbSet<TaxNumberType> TaxNumberTypes { get; set; }
    public virtual DbSet<TaxRate> TaxRates { get; set; }
    public virtual DbSet<VATPaymentMethod> VATPaymentMethods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=.;Database=FinalThesis;User=sa;Password=SQL;TrustServerCertificate=True;MultipleActiveResultSets=true");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvanceInvoice>(entity =>
        {
            entity.HasKey(e => e.IDAdvanceInvoice).HasName("PK__AdvanceI__F8D76795EE6795BD");

            entity.ToTable("AdvanceInvoice");

            entity.Property(e => e.IDAdvanceInvoice).HasColumnName("IDAdvanceInvoice");
            entity.Property(e => e.AdvanceInvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.Base0).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base13).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base25).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base5).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ExemptFromVAT)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ExemptFromVAT");
            entity.Property(e => e.ExemptionID).HasColumnName("ExemptionID");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.PDV13)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV13");
            entity.Property(e => e.PDV25)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV25");
            entity.Property(e => e.PDV5)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV5");
            entity.Property(e => e.PostingDescription).HasMaxLength(255);
            entity.Property(e => e.PurposeDescription).HasMaxLength(255);
            entity.Property(e => e.TransitionalItem).HasColumnType("decimal(10, 2)");

            //entity.HasOne(d => d.Exemption).WithMany(p => p.AdvanceInvoices)
            //    .HasForeignKey(d => d.ExemptionID)
            //    .HasConstraintName("FK__AdvanceIn__Exemp__7E02B4CC");

            entity.HasOne(d => d.Partner).WithMany(p => p.AdvanceInvoices)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdvanceIn__Partn__7D0E9093");
        });

        modelBuilder.Entity<AdvanceInvoicePayment>(entity =>
        {
            entity.HasKey(e => e.IDAdvanceInvoicePayment).HasName("PK__AdvanceI__092A4100CF8FD082");

            entity.ToTable("AdvanceInvoicePayment");

            entity.Property(e => e.IDAdvanceInvoicePayment).HasColumnName("IDAdvanceInvoicePayment");
            entity.Property(e => e.AdvanceInvoiceID).HasColumnName("AdvanceInvoiceID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.AdvanceInvoice).WithMany(p => p.AdvanceInvoicePayments)
                .HasForeignKey(d => d.AdvanceInvoiceID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdvanceIn__Advan__00DF2177");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.IDBank).HasName("PK__Bank__01BFF8BE36F48031");

            entity.ToTable("Bank");

            entity.Property(e => e.IDBank).HasColumnName("IDBank");
            entity.Property(e => e.BankAddress).HasMaxLength(255);
            entity.Property(e => e.BankName).HasMaxLength(255);
            entity.Property(e => e.BankOIB)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BankOIB");
            entity.Property(e => e.IBAN)
                .HasMaxLength(34)
                .HasColumnName("IBAN");
            entity.Property(e => e.Swift)
                .HasMaxLength(11)
                .HasColumnName("SWIFT");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.IDCity).HasName("PK__City__36D35083E4568461");

            entity.ToTable("City");

            entity.Property(e => e.IDCity).HasColumnName("IDCity");
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CityTaxCode).HasMaxLength(5);
            entity.Property(e => e.HigherTaxRate).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.IBANForTax)
                .HasMaxLength(34)
                .HasColumnName("IBANForTax");
            entity.Property(e => e.IDCountry).HasColumnName("IDCountry");
            entity.Property(e => e.LocalTaxRate).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.LowerTaxRate).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IDCountry)
                .HasConstraintName("FK_City_Country");
        });

        modelBuilder.Entity<ConnectionType>(entity =>
        {
            entity.HasKey(e => e.IDConnectionType).HasName("PK__Connecti__B54F3890718D2E0B");

            entity.ToTable("ConnectionType");

            entity.Property(e => e.IDConnectionType).HasColumnName("IDConnectionType");
            entity.Property(e => e.ConnectionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IDCountry).HasName("PK__Country__D9D5A6945280AB24");

            entity.ToTable("Country");

            entity.Property(e => e.IDCountry).HasColumnName("IDCountry");
            entity.Property(e => e.CurrencyID).HasColumnName("CurrencyID");
            entity.Property(e => e.IsEUMember).HasColumnName("IsEUMember");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OfficialNameEn).HasMaxLength(200);
            entity.Property(e => e.OfficialNameHr).HasMaxLength(200);
            entity.Property(e => e.ShortNameEn).HasMaxLength(100);
            entity.Property(e => e.ShortNameHr).HasMaxLength(100);
            entity.Property(e => e.ThreeLetterCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TwoLetterCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Currency).WithMany(p => p.Countries)
                .HasForeignKey(d => d.CurrencyID)
                .HasConstraintName("FK_Country_Currency");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.IDCurrency).HasName("PK__Currency__50890739FB655B1C");

            entity.ToTable("Currency");

            entity.Property(e => e.IDCurrency).HasColumnName("IDCurrency");
            entity.Property(e => e.CurrencyCode).HasMaxLength(3);
            entity.Property(e => e.CurrencyName).HasMaxLength(100);
            entity.Property(e => e.CurrencyNameHr).HasMaxLength(100);
            entity.Property(e => e.Symbol).HasMaxLength(10);
        });

        modelBuilder.Entity<ExemptionBasis>(entity =>
        {
            entity.HasKey(e => e.IDBasis).HasName("PK__Exemptio__36D10C7652A56D87");

            entity.ToTable("ExemptionBasis");

            entity.HasIndex(e => e.BasisName, "UQ__Exemptio__DFEC4E027DE72DB4").IsUnique();

            entity.Property(e => e.IDBasis).HasColumnName("IDBasis");
            entity.Property(e => e.BasisName).HasMaxLength(255);
        });

        modelBuilder.Entity<GiroAccount>(entity =>
        {
            entity.HasKey(e => e.IDGiroAccount).HasName("PK__GiroAcco__95EA6E795DAB662E");

            entity.ToTable("GiroAccount");

            entity.Property(e => e.IDGiroAccount).HasColumnName("IDGiroAccount");
            entity.Property(e => e.AccountName).HasMaxLength(255);
            entity.Property(e => e.IBAN)
                .HasMaxLength(34)
                .HasColumnName("IBAN");
            entity.Property(e => e.BankID).HasColumnName("IDBank");

            entity.HasOne(d => d.Bank).WithMany(p => p.GiroAccounts)
                .HasForeignKey(d => d.BankID)
                .HasConstraintName("FK__GiroAccou__IDBan__693CA210");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.IDInvoice).HasName("PK__Invoice__4DA85D70700327B5");

            entity.ToTable("Invoice");

            entity.Property(e => e.IDInvoice).HasColumnName("IDInvoice");
            entity.Property(e => e.Base0).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base13).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base25).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Base5).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DeliveryNoteNumber).HasMaxLength(50);
            entity.Property(e => e.ExemptFromVAT)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ExemptFromVAT");
            entity.Property(e => e.ExemptionID).HasColumnName("ExemptionID");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.OrderNumber).HasMaxLength(50);
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.PDV13)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV13");
            entity.Property(e => e.PDV25)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV25");
            entity.Property(e => e.PDV5)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV5");
            entity.Property(e => e.PostingDescription).HasMaxLength(255);
            entity.Property(e => e.TransitionalItem).HasColumnType("decimal(10, 2)");

            //entity.HasOne(d => d.Exemption).WithMany(p => p.Invoices)
            //    .HasForeignKey(d => d.ExemptionID)
            //    .HasConstraintName("FK__Invoice__Exempti__04AFB25B");

            entity.HasOne(d => d.Partner).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Invoice__Partner__03BB8E22");
        });

        modelBuilder.Entity<InvoiceProduct>(entity =>
        {
            entity.HasKey(e => e.IDInvoiceProduct).HasName("PK__InvoiceP__DAAE8F163B1B872D");

            entity.ToTable("InvoiceProduct");

            entity.Property(e => e.IDInvoiceProduct).HasColumnName("IDInvoiceProduct");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.InvoiceID).HasColumnName("InvoiceID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductID).HasColumnName("ProductID");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("(([Quantity]*[Price])*((1)-[Discount]/(100.0)))", false)
                .HasColumnType("numeric(34, 9)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceProducts)
                .HasForeignKey(d => d.InvoiceID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoicePr__Invoi__078C1F06");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceProducts)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoicePr__Produ__0880433F");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.IDOffer).HasName("PK__Offer__F1E50DFC5E16AEC6");

            entity.ToTable("Offer");

            entity.Property(e => e.IDOffer).HasColumnName("IDOffer");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ExemptionID).HasColumnName("ExemptionID");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.OfferName).HasMaxLength(255);
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.PDV13)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV13");
            entity.Property(e => e.PDV25)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV25");
            entity.Property(e => e.PDV5)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PDV5");
            entity.Property(e => e.Phone).HasMaxLength(50);

            //entity.HasOne(d => d.Exemption).WithMany(p => p.Offers)
            //    .HasForeignKey(d => d.ExemptionID)
            //    .HasConstraintName("FK__Offer__Exemption__76619304");

            entity.HasOne(d => d.Partner).WithMany(p => p.Offers)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Offer__PartnerID__756D6ECB");
        });

        modelBuilder.Entity<OfferProduct>(entity =>
        {
            entity.HasKey(e => e.IDOfferProduct).HasName("PK__OfferPro__9448598FE2007934");

            entity.ToTable("OfferProduct");

            entity.Property(e => e.IDOfferProduct).HasColumnName("IDOfferProduct");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.OfferID).HasColumnName("OfferID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductID).HasColumnName("ProductID");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("(([Quantity]*[Price])*((1)-[Discount]/(100.0)))", false)
                .HasColumnType("numeric(34, 9)");

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferProducts)
                .HasForeignKey(d => d.OfferID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OfferProd__Offer__793DFFAF");

            entity.HasOne(d => d.Product).WithMany(p => p.OfferProducts)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OfferProd__Produ__7A3223E8");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IDPartner).HasName("PK__Partner__C86253DC698BBA6A");

            entity.ToTable("Partner");

            entity.Property(e => e.IDPartner).HasColumnName("IDPartner");
            entity.Property(e => e.AddressNumber).HasMaxLength(50);
            entity.Property(e => e.AddressStreet).HasMaxLength(255);
            entity.Property(e => e.BillingCityID).HasColumnName("BillingCityID");
            entity.Property(e => e.BillingNumber).HasMaxLength(50);
            entity.Property(e => e.BillingStreet).HasMaxLength(255);
            entity.Property(e => e.BranchCode).HasMaxLength(50);
            entity.Property(e => e.BranchGln)
                .HasMaxLength(13)
                .HasColumnName("BranchGLN");
            entity.Property(e => e.ConnectionTypeID).HasColumnName("ConnectionTypeID");
            entity.Property(e => e.CountryID).HasColumnName("CountryID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.CityID).HasColumnName("IDCity");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ParentGln)
                .HasMaxLength(13)
                .HasColumnName("ParentGLN");
            entity.Property(e => e.PartnerName).HasMaxLength(100);
            entity.Property(e => e.PartnerTypeID).HasColumnName("PartnerTypeID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.WebAddress).HasMaxLength(100);

            entity.HasOne(d => d.BillingCity).WithMany(p => p.PartnerBillingCities)
                .HasForeignKey(d => d.BillingCityID)
                .HasConstraintName("FK_Partner_BillingCity");

            entity.HasOne(d => d.ConnectionType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.ConnectionTypeID)
                .HasConstraintName("FK_Partner_ConnectionType");

            entity.HasOne(d => d.Country).WithMany(p => p.Partners)
                .HasForeignKey(d => d.CountryID)
                .HasConstraintName("FK__Partner__Country__32AB8735");

            entity.HasOne(d => d.City).WithMany(p => p.PartnerCities)
                .HasForeignKey(d => d.CityID)
                .HasConstraintName("FK_Partner_City");

            entity.HasOne(d => d.PartnerType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Partner__Partner__339FAB6E");
        });

        modelBuilder.Entity<PartnerContact>(entity =>
        {
            entity.HasKey(e => e.IDContact).HasName("PK__PartnerC__6A51F4894052D3AA");

            entity.ToTable("PartnerContact");

            entity.Property(e => e.IDContact).HasColumnName("IDContact");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(100);

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerContacts)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnerContact_Partner");
        });

        modelBuilder.Entity<PartnerPriceList>(entity =>
        {
            entity.HasKey(e => e.IDPriceList).HasName("PK__PartnerP__98A4399B4B909830");

            entity.ToTable("PartnerPriceList");

            entity.Property(e => e.IDPriceList).HasColumnName("IDPriceList");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.PriceListTypeID).HasColumnName("PriceListTypeID");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerPriceLists)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartnerPr__Partn__3C34F16F");

            entity.HasOne(d => d.PriceListType).WithMany(p => p.PartnerPriceLists)
                .HasForeignKey(d => d.PriceListTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartnerPr__Price__3D2915A8");
        });

        modelBuilder.Entity<PartnerTaxDetail>(entity =>
        {
            entity.HasKey(e => e.IDTaxDetail).HasName("PK__PartnerT__7206BC62CCA69062");

            entity.ToTable("PartnerTaxDetail");

            entity.Property(e => e.IDTaxDetail).HasColumnName("IDTaxDetail");
            entity.Property(e => e.IBAN)
                .HasMaxLength(34)
                .HasColumnName("IBAN");
            entity.Property(e => e.PartnerID).HasColumnName("PartnerID");
            entity.Property(e => e.TaxID)
                .HasMaxLength(20)
                .HasColumnName("TaxID");
            entity.Property(e => e.TaxNumberTypeID).HasColumnName("TaxNumberTypeID");
            entity.Property(e => e.VATPaymentMethodID).HasColumnName("VATPaymentMethodID");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerTaxDetails)
                .HasForeignKey(d => d.PartnerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartnerTa__Partn__367C1819");

            entity.HasOne(d => d.TaxNumberType).WithMany(p => p.PartnerTaxDetails)
                .HasForeignKey(d => d.TaxNumberTypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartnerTa__TaxNu__37703C52");

            entity.HasOne(d => d.VATPaymentMethod).WithMany(p => p.PartnerTaxDetails)
                .HasForeignKey(d => d.VATPaymentMethodID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PartnerTa__VATPa__395884C4");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.IDPartnerType).HasName("PK__PartnerT__CF7019C52BEDE615");

            entity.ToTable("PartnerType");

            entity.Property(e => e.IDPartnerType).HasColumnName("IDPartnerType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        //modelBuilder.Entity<PDVExemption>(entity =>
        //{
        //    entity.HasKey(e => e.IDExemption).HasName("PK__PDVExemp__1E26560D4C775CFE");

        //    entity.ToTable("PDVExemption");

        //    entity.Property(e => e.IDExemption).HasColumnName("IDExemption");
        //    entity.Property(e => e.BasisID).HasColumnName("BasisID");
        //    entity.Property(e => e.ClauseCode).HasMaxLength(10);
        //    entity.Property(e => e.ClauseName).HasMaxLength(255);
        //    entity.Property(e => e.ClauseText).HasMaxLength(500);

        //    entity.HasOne(d => d.Basis).WithMany(p => p.PDVExemptions)
        //        .HasForeignKey(d => d.BasisID)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_PDVExemption_ExemptionBasis");
        //});

        modelBuilder.Entity<PriceListType>(entity =>
        {
            entity.HasKey(e => e.IDPriceListType).HasName("PK__PriceLis__23D2B688F9F83BBC");

            entity.ToTable("PriceListType");

            entity.Property(e => e.IDPriceListType).HasColumnName("IDPriceListType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IDProduct).HasName("PK__Product__B40CC6ED3028392E");

            entity.ToTable("Product");

            entity.Property(e => e.IDProduct).HasColumnName("ProductID");
            entity.Property(e => e.AdditionalCode).HasMaxLength(50);
            entity.Property(e => e.AdditionalPriceA)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AdditionalPriceB)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AdditionalPriceC)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AdditionalPriceD)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AllowancePercentage)
                .HasDefaultValue(0.000m)
                .HasColumnType("decimal(5, 3)");
            entity.Property(e => e.BaseMeasurementUnit).HasMaxLength(50);
            entity.Property(e => e.BaseUnitPrice)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Dimensions).HasMaxLength(50);
            entity.Property(e => e.Index)
                .HasDefaultValue(0.000m)
                .HasColumnType("decimal(5, 3)");
            entity.Property(e => e.Manufacturer).HasMaxLength(255);
            entity.Property(e => e.Price)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceInForeignCurrency)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceWithVAT)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PriceWithVAT");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductGroupID).HasColumnName("ProductGroupID");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.TaxNumberID).HasColumnName("TaxNumberID");
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(10);
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 3)");

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductGroupID)
                .HasConstraintName("FK__Product__Product__6EC0713C");

            entity.HasOne(d => d.TaxNumber).WithMany(p => p.Products)
                .HasForeignKey(d => d.TaxNumberID)
                .HasConstraintName("FK__Product__TaxNumb__65370702");
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.HasKey(e => e.IDProductGroup).HasName("PK__ProductG__0F0D7B021ABFFD33");

            entity.ToTable("ProductGroup");

            entity.Property(e => e.IDProductGroup).HasColumnName("ProductGroupID");
            entity.Property(e => e.GroupCode).HasMaxLength(50);
            entity.Property(e => e.GroupName).HasMaxLength(255);
            entity.Property(e => e.ProductTypeID).HasColumnName("ProductTypeID");

            entity.HasOne(d => d.ProductType).WithMany(p => p.ProductGroups)
                .HasForeignKey(d => d.ProductTypeID)
                .HasConstraintName("FK__ProductGr__Produ__6166761E");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.IDProductType).HasName("PK__ProductT__A1312F4EB148803E");

            entity.ToTable("ProductType");

            entity.Property(e => e.IDProductType).HasColumnName("ProductTypeID");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<TaxNumber>(entity =>
        {
            entity.HasKey(e => e.IDTaxNumber).HasName("PK__TaxNumbe__09108874798F8D8D");

            entity.ToTable("TaxNumber");

            entity.Property(e => e.IDTaxNumber).HasColumnName("IDTaxNumber");
            entity.Property(e => e.TaxCode).HasMaxLength(50);
            entity.Property(e => e.TaxRateID).HasColumnName("TaxRateID");
            entity.Property(e => e.TaxRatePercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.TaxRate).WithMany(p => p.TaxNumbers)
                .HasForeignKey(d => d.TaxRateID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaxNumber_TaxRate");
        });

        modelBuilder.Entity<TaxNumberType>(entity =>
        {
            entity.HasKey(e => e.IDTaxNumberType).HasName("PK__TaxNumbe__4F34558DDCB3C1C2");

            entity.ToTable("TaxNumberType");

            entity.Property(e => e.IDTaxNumberType).HasColumnName("IDTaxNumberType");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.IDTaxRate).HasName("PK__TaxRate__D1DF6CC5F99EA06B");

            entity.ToTable("TaxRate");

            entity.Property(e => e.IDTaxRate).HasColumnName("IDTaxRate");
            entity.Property(e => e.TaxRateName).HasMaxLength(100);
        });

        modelBuilder.Entity<VATPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.IDVATPaymentMethod).HasName("PK__VATPayme__6ED609E36A621D83");

            entity.ToTable("VATPaymentMethod");

            entity.Property(e => e.IDVATPaymentMethod).HasColumnName("IDVATPaymentMethod");
            entity.Property(e => e.MethodName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
