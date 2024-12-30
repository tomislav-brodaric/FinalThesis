using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.API.Services;
using FinalThesis.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class PartnerController(
    PartnerService partnerService,
    PartnerContactService partnerContactService,
    CountryService countryService, CityService cityService, PartnerTypeService partnerTypeService,
    TaxNumberTypeService taxNumberTypeService, VATPaymentMethodService vatPaymentMethodService,
    ConnectionTypeService connectionTypeService, PriceListTypeService priceListTypeService,
    PartnerTaxDetailService partnerTaxDetailService, PartnerPriceListService partnerPriceListService, IMapper mapper
) : Controller
{
    public async Task<IActionResult> Index()
    {
        var blPartners = await partnerService.GetAllPartnersAsync();
        var vmPartners = mapper.Map<IEnumerable<VMPartner>>(blPartners);
        return View(vmPartners);
    }

    public async Task<IActionResult> Details(int id)
    {
        var blPartner = await partnerService.GetPartnerByIdAsync(id);
        if (blPartner == null)
            return NotFound();
        var vmPartner = mapper.Map<VMPartner>(blPartner);
        return View(vmPartner);
    }

    public async Task<IActionResult> Create()
    {
        await InitializeSelectListsAsync();

        var vmPartner = new VMPartner
        {
            CountryID = 84
        };
        return View(vmPartner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VMPartner vmPartner)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var blPartner = mapper.Map<BLPartner>(vmPartner);
                await partnerService.AddPartnerAsync(blPartner);

                if (vmPartner.Contacts != null && vmPartner.Contacts.Any())
                {
                    foreach (var contact in vmPartner.Contacts)
                    {
                        var existingContact = await partnerContactService.GetContactByDetailsAsync(contact.FirstName, contact.LastName, blPartner.IDPartner);
                        if (existingContact == null)
                        {
                            var blContact = new BLPartnerContact
                            {
                                FirstName = contact.FirstName,
                                LastName = contact.LastName,
                                Department = contact.Department,
                                Phone = contact.Phone,
                                Fax = contact.Fax,
                                Email = contact.Email,
                                PartnerID = blPartner.IDPartner
                            };

                            await partnerContactService.AddPartnerContactAsync(blContact);
                        }
                    }
                }

                if (vmPartner.TaxNumberTypeID > 0 && vmPartner.VATPaymentMethodID > 0)
                {
                    var taxDetail = new BLPartnerTaxDetail
                    {
                        PartnerID = blPartner.IDPartner,
                        TaxNumberTypeID = vmPartner.TaxNumberTypeID,
                        VATPaymentMethodID = vmPartner.VATPaymentMethodID,
                        IBAN = vmPartner.IBAN
                    };
                    await partnerTaxDetailService.AddTaxDetailAsync(taxDetail);
                }

                if (vmPartner.PriceListTypeID > 0)
                {
                    var priceList = new BLPartnerPriceList
                    {
                        PartnerID = blPartner.IDPartner,
                        PriceListTypeID = vmPartner.PriceListTypeID,
                        Discount = vmPartner.Discount,
                        PaymentTerms = vmPartner.PaymentTerms
                    };
                    await partnerPriceListService.AddPriceListAsync(priceList);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        await InitializeSelectListsAsync();
        return View(vmPartner);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var blPartner = await partnerService.GetPartnerByIdAsync(id);
        if (blPartner == null)
            return NotFound();

        blPartner.PartnerContacts = (await partnerContactService.GetAllPartnerContactsAsync())
            .Where(contact => contact.PartnerID == blPartner.IDPartner).ToList();

        await InitializeSelectListsAsync();
        var vmPartner = mapper.Map<VMPartner>(blPartner);
        return View(vmPartner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, VMPartner vmPartner)
    {
        if (id != vmPartner.IDPartner)
            return BadRequest();

        if (ModelState.IsValid)
        {
            try
            {
                var blPartner = mapper.Map<BLPartner>(vmPartner);
                await partnerService.UpdatePartnerAsync(blPartner);

                var existingContacts = (await partnerContactService.GetAllPartnerContactsAsync())
                    .Where(contact => contact.PartnerID == blPartner.IDPartner).ToList();

                var contactsToDelete = existingContacts.Where(ec => !vmPartner.Contacts.Any(vc => vc.IDContact == ec.IDContact)).ToList();
                foreach (var contact in contactsToDelete)
                {
                    await partnerContactService.DeletePartnerContactAsync(contact.IDContact);
                }

                foreach (var contact in vmPartner.Contacts)
                {
                    var blContact = new BLPartnerContact
                    {
                        IDContact = contact.IDContact,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Department = contact.Department,
                        Phone = contact.Phone,
                        Fax = contact.Fax,
                        Email = contact.Email,
                        PartnerID = blPartner.IDPartner
                    };

                    if (blContact.IDContact > 0)
                        await partnerContactService.UpdatePartnerContactAsync(blContact);
                    else
                        await partnerContactService.AddPartnerContactAsync(blContact);
                }

                if (vmPartner.TaxNumberTypeID > 0 && vmPartner.VATPaymentMethodID > 0)
                {
                    var taxDetail = new BLPartnerTaxDetail
                    {
                        PartnerID = blPartner.IDPartner,
                        TaxNumberTypeID = vmPartner.TaxNumberTypeID,
                        VATPaymentMethodID = vmPartner.VATPaymentMethodID,
                        IBAN = vmPartner.IBAN
                    };

                    await partnerTaxDetailService.UpdateTaxDetailAsync(taxDetail);
                }

                if (vmPartner.PriceListTypeID > 0)
                {
                    var priceList = new BLPartnerPriceList
                    {
                        PartnerID = blPartner.IDPartner,
                        PriceListTypeID = vmPartner.PriceListTypeID,
                        Discount = vmPartner.Discount,
                        PaymentTerms = vmPartner.PaymentTerms
                    };

                    await partnerPriceListService.UpdatePriceListAsync(priceList);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        await InitializeSelectListsAsync();
        return View(vmPartner);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var blPartner = await partnerService.GetPartnerByIdAsync(id);
        if (blPartner == null)
            return NotFound();

        var vmPartner = mapper.Map<VMPartner>(blPartner);
        return View(vmPartner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, VMPartner vmPartner)
    {
        try
        {
            var contacts = (await partnerContactService.GetAllPartnerContactsAsync()).Where(contact => contact.PartnerID == id);
            foreach (var contact in contacts)
                await partnerContactService.DeletePartnerContactAsync(contact.IDContact);

            var taxDetails = (await partnerTaxDetailService.GetAllTaxDetailsAsync()).Where(taxDetail => taxDetail.PartnerID == id);
            foreach (var taxDetail in taxDetails)
                await partnerTaxDetailService.DeleteTaxDetailAsync(taxDetail.IDTaxDetail);

            var priceLists = (await partnerPriceListService.GetAllPriceListsAsync()).Where(priceList => priceList.PartnerID == id);
            foreach (var priceList in priceLists)
                await partnerPriceListService.DeletePriceListAsync(priceList.IDPriceList);

            await partnerService.DeletePartnerAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(vmPartner);
        }
    }


    private async Task InitializeSelectListsAsync()
    {
        var cities = await cityService.GetAllCitiesAsync();
        ViewBag.Cities = new SelectList(cities, "IDCity", "CityName");

        var countries = await countryService.GetAllCountriesAsync();
        ViewBag.Countries = new SelectList(countries, "IDCountry", "ShortNameHr");

        var partnerTypes = await partnerTypeService.GetAllPartnerTypesAsync();
        ViewBag.PartnerTypes = new SelectList(partnerTypes, "IDPartnerType", "TypeName");

        ViewBag.TaxNumberTypes = new SelectList(await taxNumberTypeService.GetAllTaxNumberTypesAsync(), "IDTaxNumberType", "TypeName");
        ViewBag.VATPaymentMethods = new SelectList(await vatPaymentMethodService.GetAllVATPaymentMethodsAsync(), "IDVATPaymentMethod", "MethodName");
        ViewBag.ConnectionTypes = new SelectList(await connectionTypeService.GetAllConnectionTypesAsync(), "IDConnectionType", "ConnectionName");
        ViewBag.PriceListTypes = new SelectList(await priceListTypeService.GetAllPriceListTypesAsync(), "IDPriceListType", "TypeName");
    }
}
